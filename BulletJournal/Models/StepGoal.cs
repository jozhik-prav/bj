using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BulletJournal
{
    /// <summary>
    /// Шаг цели
    /// </summary>
    public class StepGoal
    {
        /// <summary>
        /// Название шага
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Дата окончания шага
        /// </summary>
        public DateTime DateEnd { get; set; }
    }
}
