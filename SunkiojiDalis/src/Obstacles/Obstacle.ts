export abstract class Obstacle {
  public guid: string;
  public Id: number;
  public Sprite: string;
  public X: number;
  public Y: number;

  constructor(guid: string, itemData: any) {
    this.guid = guid;
    this.Id = itemData.id;
    this.Sprite = itemData.sprite;
    this.X = itemData.x;
    this.Y = itemData.y;
  }
  
  public getId(): number {
    return this.Id;
  }
}