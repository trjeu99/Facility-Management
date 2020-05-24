import { NgModule } from "@angular/core";
import { RouterModule } from "@angular/router";
import { CarListComponent } from "./car/car-list.component";

@NgModule({
    imports: [
        RouterModule.forChild([
            {
                path: "",
                children: [
                    {
                        path: "car",
                        component: CarListComponent,
                        data: { permission: "Pages.Group4.Car" },
                    },
                    // { path: 'car-add', component: XeDetailComponent, data: { permission: 'Pages.Group4.Car.Add', editPageState: "add" } },
                    // { path: 'car-edit', component: XeDetailComponent, data: { permission: 'Pages.Group4.Car.Edit', editPageState: "edit" } },
                    // { path: 'car-view', component: XeDetailComponent, data: { permission: 'Pages.Group4.Car.View', editPageState: "view" } },
                ],
            },
        ]),
    ],
    exports: [RouterModule],
})
export class Group4RoutingModule {}
