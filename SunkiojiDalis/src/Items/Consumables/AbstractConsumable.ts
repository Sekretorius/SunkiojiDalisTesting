import { Item } from '../Item';

export abstract class AbstractConsumable extends Item {
  constructor(guid: string, itemData: any) {
    super(guid, itemData);
  }

  public Consume(): number{
    return 0;
  }
}


