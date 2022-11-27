﻿import { Component } from "@angular/core";
import {ApexChart, ApexNonAxisChartSeries, ApexOptions, NgApexchartsModule} from "ng-apexcharts";
import { OnInit} from "@angular/core";

@Component({
    selector: 'diagram',
    templateUrl: './diagram.component.html',
    styleUrls: ['./diagram.component.css']
})
export class DiagramComponent implements OnInit {

    public chartSeries: ApexNonAxisChartSeries = [40, 32, 28, 55];

    public chartDetails: ApexChart = {
        type: 'pie',
        toolbar: {
            show: true
        }
    }
/*
    public options: ApexOptions = {
        series: [44, 55, 41, 17, 15],
        chart: {
            type: 'donut',
        },
        plotOptions: {
            pie: {
                startAngle: -90,
                endAngle: 90,
                offsetY: 10
            }
        },
        grid: {
            padding: {
                bottom: -80
            }
        },
        responsive: [{
            breakpoint: 480,
            options: {
                chart: {
                    width: 200
                },
                legend: {
                    position: 'bottom'
                }
            }
        }]
    };

    var chart = new ApexCharts(document.querySelector("#chart"), options);
    chart.render();
    
    public plotOptions: 
*/

    constructor() {
    }

    ngOnInit() {
    }
}