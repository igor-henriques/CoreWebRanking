﻿namespace CoreRankingAPI.Data;

public record DatabaseConnection
{
    public string HOST { get; set; }
    public string DB { get; set; }
    public string USER { get; set; }
    public int PORT { get; set; }
    public string PASSWORD { get; set; }
}