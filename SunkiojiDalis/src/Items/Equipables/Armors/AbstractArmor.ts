import { AbstractEquipable } from '../AbstractEquipable';

export abstract class AbstractArmor extends AbstractEquipable {
  public Defense: number;
  constructor(guid: string, itemData: any) {
    super(guid, itemData);
    this.Defense = itemData.defense;
  }
}


