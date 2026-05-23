import { HttpClient } from "@angular/common/http";
import { inject, Injectable, signal } from "@angular/core";
import { Campaign } from "../models/campaign";
import { firstValueFrom } from "rxjs";


@Injectable({
    providedIn: 'root'
})


export class CampaignService {

    private http = inject(HttpClient);

    private apiUrl = 'https://localhost:7230/api/campaigns'

    campaigns = signal<Campaign[]>([]);

    async loadCampaign() {
        try {

            const data = await firstValueFrom(this.http.get<Campaign[]>(this.apiUrl));

            this.campaigns.set(data);

        } catch (error) {
            console.error("Error Fetching Campaign: ", error);
        }
    }

}