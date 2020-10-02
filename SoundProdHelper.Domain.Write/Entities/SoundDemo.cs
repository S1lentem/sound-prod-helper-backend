using System;
using SoundProdHelper.Domain.Base;

namespace SoundProdHelper.Domain.Write.Entities
{
    public class SoundDemo : EntityBase
    {
        public string Title { get; set; }
        public string Description { get; set; }

        public Guid FileUid { get; set; }
        
        public Guid AuthorUid { get; set; }
        public virtual User Author { get; set; }
    }
}