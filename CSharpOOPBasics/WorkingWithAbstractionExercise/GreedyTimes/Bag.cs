namespace GreedyTimes
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Bag
    {
        private List<Item> bag;
        private long capacity;
        private long current;

        public Bag(long capacity)
        {
            this.capacity = capacity;
            bag = new List<Item>();
        }

        public long GoldItemsValue
        {
            get { return bag.Where(i => i is GoldItem).Sum(i => i.Value); }
        }

        public long CashItemsValue
        {
            get { return bag.Where(i => i is CashItem).Sum(i => i.Value); }
        }

        public long GemItemsValue
        {
            get { return bag.Where(i => i is GemItem).Sum(i => i.Value); }
        }

        public void AddGoldItem(GoldItem item)
        {
            if (capacity >= current + item.Value)
            {
                List<Item> goldItems = GetGoldItems();
                if (goldItems.Any(gi => gi.Key == item.Key))
                {
                    goldItems.Single(gi => gi.Key == item.Key).IncreaseValue(item.Value);
                }
                else
                {
                    bag.Add(item);
                }

                current += item.Value;
            }
        }

        public void AddGemItem(GemItem item)
        {
            if (capacity >= current + item.Value && GoldItemsValue >= GemItemsValue + item.Value)
            {
                List<Item> gemItems = GetGemItems();
                if (gemItems.Any(gi => gi.Key == item.Key))
                {
                    gemItems.Single(gi => gi.Key == item.Key).IncreaseValue(item.Value);
                }
                else
                {
                    bag.Add(item);
                }

                current += item.Value;
            }
        }

        public void AddCashItem(CashItem item)
        {
            if (capacity >= current + item.Value && GemItemsValue >= CashItemsValue + item.Value)
            {
                List<Item> cashItems = GetCashItems();
                if (cashItems.Any(gi => gi.Key == item.Key))
                {
                    cashItems.Single(gi => gi.Key == item.Key).IncreaseValue(item.Value);
                }
                else
                {
                    bag.Add(item);
                }
                current += item.Value;
            }
        }

        public List<Item> GetCashItems()
        {
            return bag.Where(i => i is CashItem).ToList();
        }

        public List<Item> GetGoldItems()
        {
            return bag.Where(i => i is GoldItem).ToList();
        }

        public List<Item> GetGemItems()
        {
            return bag.Where(i => i is GemItem).ToList();
        }

        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();

            Dictionary<string, List<Item>> bags = 
                bag.GroupBy(i => i.GetType().Name).ToDictionary(g => g.Key, g => g.ToList());

            foreach (var bag in bags.OrderByDescending(kv => kv.Value.Sum(i => i.Value)))
            {
                if (bag.Key == "CashItem")
                {
                    builder.AppendLine($"<Cash> ${bag.Value.Sum(i => i.Value)}");
                }
                else if (bag.Key == "GemItem")
                {
                    builder.AppendLine($"<Gem> ${bag.Value.Sum(i => i.Value)}");
                }
                else if (bag.Key == "GoldItem")
                {
                    builder.AppendLine($"<Gold> ${bag.Value.Sum(i => i.Value)}");
                }

                foreach (var item in bag.Value.OrderByDescending(i => i.Key).ThenBy(i => i.Value))
                {
                    builder.AppendLine($"##{item.Key} - {item.Value}");
                }
            }

            return builder.ToString().TrimEnd();
        }
    }
}
