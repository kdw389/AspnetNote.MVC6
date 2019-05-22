using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AspnetNote.MVC6.Models
{
    public class Note
    {
        /// <summary>
        /// 게시물 No(PK)
        /// </summary>
        [Key]
        public int NoteNo { get; set; }

        /// <summary>
        /// 게시물 제목
        /// </summary>
        [Required]  // Not Null
        public string NoteTitle { get; set; }

        /// <summary>
        /// 게시물 내용
        /// </summary>
        [Required]  // Not Null
        public string NoteContents { get; set; }

        /// <summary>
        /// 작성자 번호
        /// </summary>
        [Required]  // Not NUll
        public int UseerNo { get; set; }


        [ForeignKey("UserNo")]  //Join을 위한 ForeignKey 설정
        public virtual User User { get; set; }
    }
}
