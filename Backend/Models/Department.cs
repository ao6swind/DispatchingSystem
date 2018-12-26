using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Backend.Models
{
    /* 部門別
     * 　資訊部：部門管理
     * 　人資部：使用者管理
     * 　業務部：合約與營業門市管理
     * 　客服部：派工單管理
     * 　工程部：簽到退
     */
    public class Department
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}