using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PremierLeagueApi.Data;

public class TeamEntity
{
    [Key]
    public int Id { get; set; }
    public string TeamName {get; set;}
    public int ManagerId { get; set; }

    [MaxLength (100)]
    public string City {get; set;} = string.Empty;

    public int Wins {get; set;}

    public int Losses {get; set;}



}

