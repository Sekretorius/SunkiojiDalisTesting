import { AbstractWeapon } from '../AbstractWeapon';

export class CommonWeapon extends AbstractWeapon {
  public Id: number;
  public Sprite: string;
  public Name: string;
  public Weight: number;
  public Quantity: number;
  public X: number;
  public Y: number;
  public BelongsTo = -1;
  public Damage: number;

  constructor(guid: string, itemData: any) {
    super(guid, itemData);
  }
}