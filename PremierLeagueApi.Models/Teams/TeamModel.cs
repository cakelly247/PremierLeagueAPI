using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Collections;
using PremierLeagueApi.Data.Entities;
namespace PremierLeagueApi.Models;

public class TeamModel
{
[Required]
public string TeamName {get; set;}

[MaxLength(100)]
public string City { get; set; }

[Range(0, int.MaxValue)]
public int Wins {get; set;}

[Range(0, int.MaxValue)]
public int Losses {get; set;}

public List<PlayerEntity> Players {get; set;}




}