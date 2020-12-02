using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Dev.App.ViewModels
{
    public class CustomerViewModel
    {
        [Key]
        public Guid Id { get; set; }
        
        [DisplayName("Cliente")]
        [Required(ErrorMessage = "O campo {0} é obrigátorio")]
        public string Name { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigátorio")]
        public string CNPJ { get; set; }
        
        [Required(ErrorMessage = "O campo {0} é obrigátorio")]
        public string Email { get; set; }

        [DisplayName("Segmento")]
        [Required(ErrorMessage = "O campo {0} é obrigátorio")]
        public Guid SegmentId { get; set; }
        public SegmentViewModel Segment { get; set; }
        public IEnumerable<SegmentViewModel> Segments { get; set; }
        public IEnumerable<ProspectViewModel> Prospects { get; set; }
    }
}
