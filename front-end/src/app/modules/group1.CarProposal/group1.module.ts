import { NgModule } from "@angular/core";

import {
    MenuClientServiceProxy,
    DemoModelServiceProxy,
} from "@shared/service-proxies/service-proxies";

import { TableModule } from "primeng/table";
import { FormsModule, ReactiveFormsModule } from "@angular/forms";
import { BrowserModule } from "@angular/platform-browser";
import { CommonModule } from "@angular/common";
import { Group1RoutingModule } from "./group1-routing.module";
import { Group1ServiceProxyModule } from "./group1.service-proxy.module";
import { CarProposalComponent } from './car-proposal/car-proposal.component';
import { CalendarModule } from "primeng/primeng";

@NgModule({
    imports: [
        CommonModule,
        FormsModule,
        TableModule,
        Group1RoutingModule,
        Group1ServiceProxyModule,
        CalendarModule,
        ReactiveFormsModule
    ],
    declarations: [CarProposalComponent],
    providers: [],
})
export class Group1Module {}
