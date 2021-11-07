export abstract class Item {
  public guid: string;
  public Id: number;
  public Sprite: string;
  public Name: string;
  public Weight: number;
  public Quantity: number;
  public X: number;
  public Y: number;
  public BelongsTo: number;

  constructor(guid: string, itemData: any) {
    this.guid = guid;
    this.Id = itemData.id;
    this.Sprite = itemData.sprite;
    this.Name = itemData.name;
    this.Weight = itemData.weight;
    this.Quantity = itemData.quantity;
    this.X = itemData.x;
    this.Y = itemData.y;
    this.BelongsTo = itemData.belongsTo;
  }
}