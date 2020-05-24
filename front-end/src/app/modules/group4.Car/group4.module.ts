import { NgModule } from "@angular/core";

import {
    MenuClientServiceProxy,
    DemoModelServiceProxy,
} from "@shared/service-proxies/service-proxies";

import { TableModule } from "primeng/table";
import { FormsModule } from "@angular/forms";
import { BrowserModule } from "@angular/platform-browser";
import { CommonModule } from "@angular/common";
import { Group4RoutingModule } from "./group4.routing.module";
import { Group4ServiceProxyModule } from "./group4.service-proxy.module";
import { CarListComponent } from "./car/car-list.component";

@NgModule({
    imports: [
        Group4RoutingModule,
        Group4ServiceProxyModule,
        CommonModule,
        FormsModule,
        TableModule,
    ],
    declarations: [CarListComponent],
    providers: [],
})
export class Group4Module {}
