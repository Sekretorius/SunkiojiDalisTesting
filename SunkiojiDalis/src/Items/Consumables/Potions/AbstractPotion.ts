import { AbstractConsumable } from '../AbstractConsumable';

export abstract class AbstractPotion extends AbstractConsumable {
  public Ability: string;

  constructor(guid: string, itemData: any) {
    super(guid, itemData);
    this.Ability = itemData.ability;
  }
}


