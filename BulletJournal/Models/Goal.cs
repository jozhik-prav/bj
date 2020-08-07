using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BulletJournal
{
    /// <summary>
    /// Цель
    /// </summary>
    public class Goal
    {
        /// <summary>
        /// Идентификатор цели
        /// </summary>
        public Guid Id = new Guid();

        /// <summary>
        /// Название цели
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Описание цели
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Категория цели
        /// </summary>
        public Category Category { get; set; }

        /// <summary>
        /// Дата окончания цели
        /// </summary>
        public DateTime DateEnd { get; set; }

        /// <summary>
        /// Шаги достижения цели
        /// </summary>
        public StepGoal[] Steps { get; set; }

        /// <summary>
        /// Картинка цели
        /// </summary>
        public string Image { get; set; }
    }
}
