using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using PremierLeagueApi.Data.Entities;

namespace PremierLeagueApi.Data;

public class TeamEntity
{
    [Key]
    public int Id { get; set; }

    [Required]
    public string TeamName {get; set;} = string.Empty;

    [ForeignKey("Managers")]
    public int ManagerId { get; set; }

    [MaxLength (100)]
    public string City {get; set;} = string.Empty;

    [Required]
    public int Wins {get; set;}

    [Required]
    public int Losses {get; set;}
    
    public List<PlayerEntity> Players {get; set;}
}

