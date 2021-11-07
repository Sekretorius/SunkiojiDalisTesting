import { AbstractFood } from '../AbstractFood';

export class CommonFood extends AbstractFood {
  Id: number;
  Sprite: string;
  Name: string;
  Weight: number;
  Quantity: number;
  X: number;
  Y: number;
  BelongsTo = -1;
  Health: number;

  constructor(guid: string, itemData: any) {
    super(guid, itemData);
  }
}