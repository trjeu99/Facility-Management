import { NgModule } from "@angular/core";

import {
    MenuClientServiceProxy,
    DemoModelServiceProxy,
} from "@shared/service-proxies/service-proxies";

import { TableModule } from "primeng/table";
import { FormsModule } from "@angular/forms";
import { BrowserModule } from "@angular/platform-browser";
import { CommonModule } from "@angular/common";
import { Group0RoutingModule } from "./group0.routing.module";
import { Group0ServiceProxyModule } from "./group0.service-proxy.module";
import { CarListComponent } from "./car/car-list.component";
import { CarEditComponent } from "./car/car-edit.component";

@NgModule({
    imports: [
        Group0RoutingModule,
        Group0ServiceProxyModule,
        CommonModule,
        FormsModule,
        TableModule,
    ],
    declarations: [CarListComponent, CarEditComponent],
    providers: [],
})
export class Group0Module {}
