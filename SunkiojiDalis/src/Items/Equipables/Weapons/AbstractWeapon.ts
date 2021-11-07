import { AbstractEquipable } from '../AbstractEquipable';

export abstract class AbstractWeapon extends AbstractEquipable {
  public Damage: number;
  constructor(guid: string, itemData: any) {
    super(guid, itemData);
    this.Damage = itemData.damage;
  }
}

