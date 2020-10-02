using System;
using System.Linq;
using System.Linq.Expressions;
using SoundProdHelper.Domain.Base;
using SoundProdHelper.Domain.Specifications.Internal;

namespace SoundProdHelper.Domain.Specifications
{
    public class FilterSpecificationBase<T>
        where T: EntityBase
    {
        public Expression<Func<T, bool>> Predicate { get; set; }

        // Logical AND overload, when it is necessary to filter by two or more predicates
        // Example condition: person => person.Age > 18 && person.Age < 45
        public static FilterSpecificationBase<T> operator &(FilterSpecificationBase<T> left, FilterSpecificationBase<T> right)
        {
            return Combine(left, right, Expression.AndAlso);
        }

        // Logical OR overload. when it is necessary to filter out at least one predicate
        // Example condition: person => person.Age == 18 || person.Age == 16
        public static FilterSpecificationBase<T> operator |(FilterSpecificationBase<T> left, FilterSpecificationBase<T> right)
        {
            return Combine(left, right, Expression.OrElse);
        }

        // Logical denial.
        public static FilterSpecificationBase<T> operator !(FilterSpecificationBase<T> original)
        {
            return new CombinedSpecification<T>(
                Expression.Lambda<Func<T, bool>>(Expression.Negate(original.Predicate.Body),
                    original.Predicate.Parameters));
        }

        // Combines two expressions into one, replacing their parameters with one(Visitor class)
        private static FilterSpecificationBase<T> Combine(FilterSpecificationBase<T> left, FilterSpecificationBase<T> right,
            Func<Expression, Expression, BinaryExpression> combiner)
        {
            var leftExpression = left.Predicate;
            var rightExpression = right.Predicate;
            var arg = Expression.Parameter(typeof(T));

            var combined = combiner.Invoke(
                new ReplaceParameterVisitor { { leftExpression.Parameters.Single(), arg } }.Visit(leftExpression.Body),
                new ReplaceParameterVisitor { { rightExpression.Parameters.Single(), arg } }.Visit(rightExpression.Body)
            );

            return new CombinedSpecification<T>(Expression.Lambda<Func<T, bool>>(combined, arg));
        }

        private Func<T, bool> _function;

        private Func<T, bool> Function => _function ??= Predicate.Compile();

        public bool IsSatisfiedBy(T entity)
        {
            return Function.Invoke(entity);
        }
    }
}