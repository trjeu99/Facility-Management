import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { MenuClientComponent } from '@app/gwebsite/menu-client/menu-client.component';
import { DemoModelsComponent } from './demoModels/demoModels.component';
import { CarComponent } from "./car/car.component";
import { CarAddComponent } from "./car/car-add.component";

const routes: Routes = [
    {
        path: '',
        children: [
            {
                path: 'menu-client', component: MenuClientComponent,
                data: { permission: 'Pages.Administration.MenuClient' }
            },
            {
                path: 'demo-model', component: DemoModelsComponent,
                data: { permission: 'Pages.Administration.DemoModel' }
            },
            {
                path: 'car', component: CarAddComponent,
                data: { permission: 'Pages.Administration.Car' },
            },
            {
                path: 'car-add', component: CarAddComponent,
                data: { permission: 'Pages.Administration.Car.Create' },
            }
        ]
    }
]

@NgModule({
    imports: [
        RouterModule.forChild(routes)
    ],
    exports: [
        RouterModule
    ]
})
export class GWebsiteRoutingModule { }
