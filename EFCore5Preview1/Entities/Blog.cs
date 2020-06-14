using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFCore5Preview1.Entities
{
    public class Blog
    {
        private string _mainTitle;

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [BackingField(nameof(_mainTitle))]
        public string Title { get { return _mainTitle; } }

        public void SetTitle(string title) 
        {
            _mainTitle = title;
        }
    }
}