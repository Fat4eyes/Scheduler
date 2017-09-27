using System;
using System.ComponentModel.DataAnnotations;

namespace Scheduler.Models
{
    public class Task
    {
        public int TaskId { get; set; }

        [Required(ErrorMessage = "Введи задачу")]
        [Display(Name = "Задача")]
        public string Topic { get; set; }

        [Display(Name = "Заметка")]
        public string Note { get; set; }

        [Display(Name = "Дата")]
        [DataType(DataType.Date)]
        [Required(ErrorMessage = "Введи дату")]
        [DisplayFormat(DataFormatString = "{0:dd'/'MM'/'yyyy}", ApplyFormatInEditMode = true)]
        public DateTime Date { get; set; }
    }
}