using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace SoundProdHelper.Domain.Specifications.Internal
{
    internal class ReplaceParameterVisitor : ExpressionVisitor, IEnumerable<KeyValuePair<ParameterExpression, ParameterExpression>>
    {
        private readonly Dictionary<ParameterExpression, ParameterExpression> _parameterMappings =
            new Dictionary<ParameterExpression, ParameterExpression>();

        protected override Expression VisitParameter(ParameterExpression node)
        {
            return _parameterMappings.TryGetValue(node, out var newValue) ? newValue : node;
        }

        public void Add(ParameterExpression parameterToReplace, ParameterExpression replaceWith)
        {
            _parameterMappings.Add(parameterToReplace, replaceWith);
        }

        public IEnumerator<KeyValuePair<ParameterExpression, ParameterExpression>> GetEnumerator()
        {
            return _parameterMappings.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}