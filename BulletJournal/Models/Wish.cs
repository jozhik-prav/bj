using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BulletJournal
{
    /// <summary>
    /// Желание
    /// </summary>
    public class Wish
    {
        /// <summary>
        /// Идентификатор желания
        /// </summary>
        public Guid Id {get; set; } = Guid.NewGuid();

        /// <summary>
        /// Навзание желания
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Описание желания
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Категория желания
        /// </summary>
        public Category Category { get; set; }

        /// <summary>
        /// Приоритет желания
        /// </summary>
        public int Priority { get; set; }

        /// <summary>
        /// Изображение желания
        /// </summary>
        public string Image { get; set; }

        /// <summary>
        /// Исполнено ли желание
        /// </summary>
        public bool IsComplete { get; set; }
    }
}
