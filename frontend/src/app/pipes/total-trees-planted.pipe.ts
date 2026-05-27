// pipes/total-trees-planted.pipe.ts
import { Pipe, PipeTransform } from '@angular/core';
import { Campaign } from '../core/models/campaign';

@Pipe({ name: 'totalTreesPlanted', standalone: true })
export class TotalTreesPlantedPipe implements PipeTransform {
    transform(campaigns: Campaign[]): number {
        return campaigns.reduce((sum, c) => sum + c.plantedTrees, 0);
    }
}