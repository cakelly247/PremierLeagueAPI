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

    [Required, MaxLength(100)]
    public string TeamName {get; set;} = string.Empty;


    [Required, MaxLength (100)]
    public string City {get; set;} = string.Empty;

    [Required]
    public int Wins {get; set;} = 0;

    [Required]
    public int Losses {get; set;} = 0;
    
    public int ManagerId { get; set; } = 0;
    
    public List<PlayerEntity> Players {get; set;}
}

