import { AbstractArmor } from '../AbstractArmor';

export class CommonArmor extends AbstractArmor {
  public Id: number;
  public Sprite: string;
  public Name: string;
  public Weight: number;
  public Quantity: number;
  public X: number;
  public Y: number;
  public BelongsTo = -1;
  public Defense: number;

  constructor(guid: string, itemData: any) {
    super(guid, itemData);
  }
}
