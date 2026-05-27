import { Component, inject, signal } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { CampaignService } from './core/services/campaign';
import { CommonModule } from '@angular/common';
import { ActiveCampaignsCountPipe } from './pipes/active-campaigns-count.pipe';
import { TotalTreesPlantedPipe } from './pipes/total-trees-planted.pipe';
import { ClampPipe } from './pipes/clamp.pipe';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [
    RouterOutlet,
    CommonModule,
    ActiveCampaignsCountPipe,
    TotalTreesPlantedPipe,
    ClampPipe],
  templateUrl: './app.html',
  styleUrl: './app.scss'
})
export class App {
  protected readonly title = signal('EcoAct.UI');

  campaignService = inject(CampaignService);


  ngOnInit(): void {
    this.campaignService.loadCampaigns();
  }

}
