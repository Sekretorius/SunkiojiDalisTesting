import { AbstractPotion } from '../AbstractPotion';

export class LegendaryPotion extends AbstractPotion {
  Id: number;
  Sprite: string;
  Name: string;
  Weight: number;
  Quantity: number;
  X: number;
  Y: number;
  BelongsTo = -1;
  Ability: string;

  constructor(guid: string, itemData: any) {
    super(guid, itemData);
  }
}
