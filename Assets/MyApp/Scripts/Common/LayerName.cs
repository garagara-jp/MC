/// <summary>
/// レイヤー名を定数で管理するクラス
/// </summary>
public static class LayerName
{
	public const int Default = 0;
	public const int TransparentFX = 1;
	public const int IgnoreRaycast = 2;
	public const int Water = 4;
	public const int UI = 5;
	public const int FloorLayer = 8;
	public const int PlayerLayer = 9;
	public const int DamagedPlayerLayer = 10;
	public const int EnemyLayer = 11;
	public const int MoneyLayer = 12;
	public const int WallLayer = 13;
	public const int PlayerAttackLayer = 14;
	public const int EnemyAttackLayer = 15;
	public const int DefaultMask = 1;
	public const int TransparentFXMask = 2;
	public const int IgnoreRaycastMask = 4;
	public const int WaterMask = 16;
	public const int UIMask = 32;
	public const int FloorLayerMask = 256;
	public const int PlayerLayerMask = 512;
	public const int DamagedPlayerLayerMask = 1024;
	public const int EnemyLayerMask = 2048;
	public const int MoneyLayerMask = 4096;
	public const int WallLayerMask = 8192;
	public const int PlayerAttackLayerMask = 16384;
	public const int EnemyAttackLayerMask = 32768;
}
