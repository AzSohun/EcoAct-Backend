// pipes/active-campaigns-count.pipe.ts
import { Pipe, PipeTransform } from '@angular/core';
import { Campaign } from '../core/models/campaign';

@Pipe({ name: 'activeCampaignsCount', standalone: true })
export class ActiveCampaignsCountPipe implements PipeTransform {
    transform(campaigns: Campaign[]): number {
        return campaigns.filter(c => c.isActive).length;
    }
}