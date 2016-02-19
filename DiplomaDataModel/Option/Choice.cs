using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiplomaDataModel.Option
{
    public class Choice
    {
        [Key]
        public int ChoiceId { get; set; }

        [ForeignKey("YearTerm")]
        public int? YearTermId { get; set; }
        [ForeignKey("YearTermId"), Display(Name = "Year / Semester")]
        public virtual YearTerm YearTerm { get; set; }

        [MaxLength(9), RegularExpression(@"A00[0-9]{6}", ErrorMessage = "Invalid Students ID"), Display(Name = "Student ID")]
        public string StudentId { get; set; } 
<<<<<<< HEAD
        [MaxLength(40)]
        [Required]
        public string StudentFirstName { get; set; }
        [MaxLength(40)]
        [Required]
=======
        [MaxLength(40), Display(Name = "Student First Name")]
        public string StudentFirstName { get; set; }
        [MaxLength(40), Display(Name = "Student Last Name")]
>>>>>>> f65c376a57fb21e908042afa1f81f400fc7ee7d2
        public string StudentLastName { get; set; }

        [Display(Name = "First Choice: ")]
        [ForeignKey("FirstOption")]
        public int? FirstChoiceOptionId { get; set; }
        [ForeignKey("FirstChoiceOptionId"), Display(Name = "First Choice: ")]
        public Option FirstOption { get; set; }

        [ForeignKey("SecondOption")]
        public int? SecondChoiceOptionId { get; set; }
        [ForeignKey("SecondChoiceOptionId"), Display(Name = "Second Choice: ")]
        public Option SecondOption { get; set; }

        [ForeignKey("ThirdOption")]
        public int? ThirdChoiceOptionId { get; set; }
        [ForeignKey("ThirdChoiceOptionId"), Display(Name = "Third Choice: ")]
        public Option ThirdOption { get; set; }

        [ForeignKey("FourthOption")]
        public int? FourthChoiceOptionId { get; set; }
        [ForeignKey("FourthChoiceOptionId"), Display(Name = "Fourth Choice: ")]
        public Option FourthOption { get; set; }

        [ScaffoldColumn(false)]
        public DateTime SelectionDate {
            get {
                return DateTime.Now;
            } set {
                value = DateTime.Now;
            }
        }

    }
}
