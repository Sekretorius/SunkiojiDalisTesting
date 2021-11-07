import { AbstractConsumable } from '../AbstractConsumable';

export abstract class AbstractFood extends AbstractConsumable {
  public Health: number;

  constructor(guid: string, itemData: any) {
    super(guid, itemData);
    this.Health = itemData.health;
  }
}


