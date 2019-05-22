﻿using System.ComponentModel.DataAnnotations;

namespace AspnetNote.MVC6.Models
{
    public class User
    {
        /// <summary>
        /// 사용자 번호(PK)
        /// </summary>
        [Key]   //PK 설정
        public int UserNo { get; set; }

        /// <summary>
        /// 사용자 이름
        /// </summary>
        [Required]  //Not Null 설정
        public string UserName { get; set; }

        /// <summary>
        /// 사용자ID
        /// </summary>
        [Required]  //Not Null 설정
        public string UserId { get; set; }

        /// <summary>
        /// 사용자 Password
        /// </summary>
        [Required]  //Not Null 설정
        public string UserPassword { get; set; }
    }
}
