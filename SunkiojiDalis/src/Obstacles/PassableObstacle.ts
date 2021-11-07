import { Obstacle } from './Obstacle';

export class PassableObstacle extends Obstacle {
  public Type: string;

  constructor(guid: string, characterData: any) {
    super(guid, characterData);
    this.Type = characterData.type;
  }
}