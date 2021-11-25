using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Guild
{
    public class Guild
    {
        private List<Player> roaster;

        public Guild(string name, int capacity)
        {
            this.Name = name;
            this.Capacity = capacity;
            this.roaster = new List<Player>();
        }

        public string Name { get; set; }
        public int Capacity { get; set; }
        public int Count { get => this.roaster.Count; }

        public void AddPlayer(Player player)
        {
            if (this.roaster.Count < this.Capacity)
            {
                this.roaster.Add(player);
            }
        }

        public bool RemovePlayer(string name)
        {
            if (this.roaster.Any(p => p.Name == name))
            {
                this.roaster.Remove(this.roaster.Where(p => p.Name == name).FirstOrDefault());
                return true;
            }
            else
            {
                return false;
            }
        }

        public void PromotePlayer(string name)
        {
            this.roaster.Where(p => p.Name == name).FirstOrDefault().Rank = "Member";
        }

        public void DemotePlayer(string name)
        {
            this.roaster.Where(p => p.Name == name).FirstOrDefault().Rank = "Trial";
        }

        public Player[] KickPlayersByClass(string classs)
        {
            Player[] players = new Player[this.roaster.Count];
            players = this.roaster.Where(p => p.Class == classs).ToArray();
            this.roaster.RemoveAll(p => p.Class == classs);

            return players;
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Players in the guild: {this.Name}");
            foreach (Player player in this.roaster)
            {
                sb.AppendLine($"{player}");
            }

            return sb.ToString().TrimEnd();
        }
    }
}
