using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace test_mod.Items
{
    public class test : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("gun"); //Ϊ�����������
            Tooltip.SetDefault("������ĵ�һ��ǹ.\n����һ��Զ��������ʾ����");//������������ʾ�����\n���л���
        }
        public override void SetDefaults()
        {
            //������������Ʒ�Ļ�������
            Item.damage = 210000000;//��Ʒ�Ļ����˺�
            Item.crit = -100;//��Ʒ�ı�����
            Item.DamageType = DamageClass.Ranged;//��Ʒ���˺�����
            Item.width = 40;//��Ʒ�Ե�������ʽ���ڵ���ײ����
            Item.height = 40;//��Ʒ�Ե�������ʽ���ڵ���ײ��߶�
            Item.useTime = 1;//��Ʒһ��ʹ����������ʱ�䣨��֡Ϊ��λ��(�������1��60֡)
            Item.shoot = 304;//��Ʒ����ĵ�ĻID(�����)
            Item.shootSpeed = 24f;//��Ʒ����ĵ�Ļ�ٶȣ�����/֡����һ����鳤16���أ�
            Item.useAnimation = 5;//��Ʒ����ʹ�ö�����������ʱ��
            Item.useStyle = ItemUseStyleID.Shoot;//ʹ�ö��� swingΪ���� shootΪ���
            Item.knockBack = 2;//��Ʒ����
            Item.value = Item.buyPrice(1, 22, 0, 0);//��ֵ  buyprice��������ֱ�����ó�ֱ�۵�Ǯ����
            Item.rare = ItemRarityID.Pink;//ϡ�ж�
            Item.UseSound = SoundID.Item36;//ʹ��ʱ������
            Item.autoReuse = true;//�Զ�����
                                  //������������������
            Item.noUseGraphic = false;//Ϊtrueʱ��������Ʒʹ�ö���
            Item.noMelee = true;//Ϊtrueʱ��ȡ����Ʒ��ս�ж�
            Item.useAmmo = AmmoID.Bullet;//Ϊ����AmmoIDʱ��������ָ����ҩ
            Item.mana = 0;//Ϊ���������ʱÿ��ʹ�û�����ħ��ֵ
            Item.scale = 1.2f;//��Ʒʹ�ö����Ĵ�С
        }
        public override void MeleeEffects(Player player, Rectangle hitbox)
        {
            //��������������ս����ʱ�����Ĳ�����ͨ��Ϊ��������
            //Dust.NewDust(hitbox.TopLeft(), hitbox.Width, hitbox.Height, DustID.Torch, 0, 0, 0, default, 2);
            base.MeleeEffects(player, hitbox);
        }
        public override void OnHitNPC(Player player, NPC target, int damage, float knockBack, bool crit)
        {
            //������Ϊ��ս������NPCʱ���еĲ�����ͨ��Ϊ������Ļ����BUFF
            target.AddBuff(BuffID.OnFire, 120);//addbuff������һ������ΪҪ�ϵ�BUFFID���ڶ���Ϊ����ʱ�䣨֡��
            player.AddBuff(BuffID.NebulaUpLife3, 30);//Ϊ�����Ӱ������ƻظ�BUFF
                                                     //Զ�������Ͳ���Ҫ��
            base.OnHitNPC(player, target, damage, knockBack, crit);
        }
        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();//����һ���䷽
            recipe.AddIngredient(ItemID.Wood, 10);//��ӵڶ��ֲ��ϣ�10ľ�ģ�
            recipe.AddTile(TileID.Campfire);//����ϳ�վ(����Ϊ����Ȥ�Ҹĳ�������)
            recipe.Register();
        }
     }
}