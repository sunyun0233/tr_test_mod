using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

// 确保这个文件一定要放在Items/Armors/文件夹里，与命名空间匹配
// 这个套装的贴图来自ExampleMOD
namespace test_mod.Items.Armors {
    // 注意这里，这是C#里面的一个神奇的语法
    // 作用是给一个类附加一个属性
    // 比如这里就是给这个类附加一个装备样式为头盔的属性，这样TML就会把它识别成头盔
    [AutoloadEquip(EquipType.Body)]
    public class ExampleBreastplate : ModItem {
        // 设置物品描述的地方
        public override void SetStaticDefaults() {
            base.SetStaticDefaults();
            // SetDefaults也可以不写
            DisplayName.SetDefault( "模板胸甲");
            Tooltip.SetDefault( "被魔改了的胸甲"
                + "\n免疫灼烧debuff"
                + "\n+500生命上限"
                + "\n增加回血能力");
        }

        public override void SetDefaults() {
            Item.width = 18;
            Item.height = 18;
            Item.value = Item.sellPrice(0, 1, 0, 0);
            Item.rare = ItemRarityID.Orange;
            // 装备的防御值
            Item.defense = 75;
        }

        public override void UpdateEquip(Player player) {
            // 免疫灼伤debuff
            player.buffImmune[BuffID.OnFire] = true;

            // 增加生命上限50
            player.statLifeMax2 += 500;

            // 增加2点生命恢复，虽然看起来不多，其实在游戏里还挺可观的
            player.lifeRegen += 20;
        }

            public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();//创建一个配方
            recipe.AddIngredient(ItemID.Wood, 10);//添加第二种材料（10木材）
            recipe.AddTile(TileID.Campfire);//加入合成站(这里为了有趣我改成了篝火)
            recipe.Register();
        }
    }
}
