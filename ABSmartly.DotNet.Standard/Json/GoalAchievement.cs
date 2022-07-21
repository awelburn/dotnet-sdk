﻿using System.Collections.Generic;

namespace ABSmartly.Json;

//@JsonInclude(JsonInclude.Include.NON_NULL)
//@JsonIgnoreProperties(ignoreUnknown = true)
public class GoalAchievement
{
    public GoalAchievement()
    {
        
    }

    public GoalAchievement(string name, long achievedAt, Dictionary<string, object> properties)
    {
        Name = name;
        AchievedAt = achievedAt;
        Properties = properties;
    }

    public string Name { get; set; }
    public long AchievedAt { get; set; }
    public Dictionary<string, object> Properties { get; set; }

    protected bool Equals(GoalAchievement other)
    {
        return Name == other.Name && AchievedAt == other.AchievedAt && Equals(Properties, other.Properties);
    }

    public override bool Equals(object obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((GoalAchievement)obj);
    }

    public override int GetHashCode()
    {
        unchecked
        {
            var hashCode = (Name != null ? Name.GetHashCode() : 0);
            hashCode = (hashCode * 397) ^ AchievedAt.GetHashCode();
            hashCode = (hashCode * 397) ^ (Properties != null ? Properties.GetHashCode() : 0);
            return hashCode;
        }
    }

    public override string ToString()
    {
        return "GoalAchievement{" +
               "name='" + Name + '\'' +
               ", achievedAt=" + AchievedAt +
               ", properties=" + Properties +
               '}';
    }
}