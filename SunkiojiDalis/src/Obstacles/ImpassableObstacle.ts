import { Obstacle } from './Obstacle';

export class ImpassableObstacle extends Obstacle {
  public Effect: string;

  constructor(guid: string, characterData: any) {
    super(guid, characterData);
    this.Effect = characterData.effect;
  }
}