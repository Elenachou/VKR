﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MieCalc
{
    public static class Calculator
    {
        public static ResultData Calculate(double wavelength, double rangeMin, double rangeMax, double steps, double numberOfDiscs, double relativeHumidity)
        {


//Заполнение массивов длинами волн и комплексными оптическими показателями преломления
//для различных веществ в видимой и инфракрасной области спектра
//Пыль

  //Длины волн
        double [] DustLambda = {0.2000,0.2500,0.3000,0.3371,0.4000,0.4880,0.5145,
        0.5500,0.6328,0.6943,0.8600,1.0600,1.3000,1.5360,1.8000,2.0000,2.2500,2.5000,2.7000,
        3.0000,3.2000,3.3923,3.5000,3.7500,4.0000,4.5000,5.0000,5.5000,6.0000,6.2000,6.5000,
        7.2000,7.9000,8.2000,8.5000,8.7000,9.0000,9.2000,9.5000,9.8000,10.000,10.591,11.000,
        11.500,12.500,13.000,14.000,14.800,15.000,16.400,17.200,18.000,18.500,20.000,21.300,
        22.500,25.000,27.900,30.000,35.000,40.000};

  //Действительные части комплексных оптических показателей преломления пыли
        double [] DustMN1 = {1.530,1.530,1.530,1.530,1.530,1.530,1.530,1.530,1.530,
        1.530,1.520,1.520,1.460,1.400,1.330,1.260,1.220,1.180,1.180,1.160,1.220,1.260,
        1.280,1.270,1.260,1.260,1.250,1.220,1.150,1.140,1.130,1.400,1.150,1.130,1.300,
        1.400,1.700,1.720,1.730,1.740,1.750,1.620,1.620,1.590,1.510,1.470,1.520,1.570,
        1.570,1.600,1.630,1.640,1.640,1.680,1.770,1.900,1.970,1.890,1.800,1.900,2.100};
  
  //Мнимые части комплексных оптических показателей преломления пыли
        double [] DustMN2 = {7.00E-2,3.00E-2,8.00E-3,8.00E-3,8.00E-3,8.00E-3,8.00E-3,
        8.00E-3,8.00E-3,8.00E-3,8.00E-3,8.00E-3,8.00E-3,8.00E-3,8.00E-3,8.00E-3,9.00E-3,
        9.00E-3,1.30E-2,1.20E-2,1.00E-2,1.30E-2,1.10E-2,1.10E-2,1.20E-2,1.40E-2,1.60E-2,
        2.10E-2,3.70E-2,3.90E-2,4.20E-2,5.50E-2,4.00E-2,7.40E-2,9.00E-2,1.00E-1,1.40E-1,
        1.50E-1,1.62E-1,1.62E-1,1.62E-1,1.20E-1,1.05E-1,1.00E-1,9.00E-2,1.00E-1,8.52E-2,
        1.00E-1,1.00E-1,1.00E-1,1.00E-1,1.15E-1,1.20E-1,2.20E-1,2.80E-1,2.80E-1,2.40E-1,
        3.20E-1,4.20E-1,5.00E-1,6.00E-1};

    //B1-Аэрозоль
    //Длины волн
        double [] B1Lambda = {0.2000,0.2250,0.2500,0.2750,0.3000,0.3250,0.3500,0.3750,
        0.4000,0.4250,0.4500,0.4750,0.5000,0.5250,0.5500,0.5750,0.6000,0.6250,0.6500,0.6750,
        0.7000,0.7250,0.7500,0.7750,0.8000,0.8250,0.8500,0.8750,0.9000,0.9250,0.9500,0.9750,
        1.00,1.20,1.40,1.60,1.80,2.00,2.20,2.40,2.60,2.65,2.70,2.75,2.80,2.85,2.90,2.95,3.00,
        3.05,3.10,3.15,3.20,3.25,3.30,3.35,3.40,3.45,3.50,3.6,3.7,3.8,3.9,4.0,4.1,4.2,4.3,4.4,
        4.5,4.6,4.7,4.8,4.9,5.0,5.1,5.2,5.3,5.4,5.5,5.6,5.7,5.8,5.9,6.0,6.1,6.2,6.3,6.4,6.5,
        6.6,6.7,6.8,6.9,7.0,7.1,7.2,7.3,7.4,7.5,7.6,7.7,7.8,7.9,8.0,8.2,8.4,8.6,8.8,9.0,9.2,
        9.4,9.6,9.8,10.0,10.5,11.0,11.5,12.0,12.5,13.0,13.5,14.0,14.5,15.0,15.5,16.0,16.5,17.0,
        17.5,18.0,18.5,19.0,19.5,20.0,21.0,22,23,24,25,26,27,28,29,30,32,34,36,38,40};
  //Действительные части комплексных оптических показателей преломления B1-Аэрозоля
        double [] B1MN1 = {1.392,1.392,1.392,1.392,1.392,1.392,1.392,1.392,1.392,1.392,
        1.392,1.392,1.392,1.392,1.392,1.392,1.392,1.392,1.392,1.392,1.392,1.392,1.392,
        1.392,1.392,1.392,1.392,1.392,1.392,1.392,1.392,1.392,1.392,1.392,1.392,1.392,
        1.392,1.392,1.392,1.392,1.392,1.392,1.391,1.388,1.386,1.383,1.382,1.381,1.386,
        1.390,1.393,1.396,1.402,1.408,1.413,1.420,1.426,1.433,1.440,1.448,1.452,1.455,
        1.458,1.464,1.469,1.475,1.481,1.487,1.490,1.493,1.497,1.500,1.502,1.505,1.508,
        1.510,1.511,1.505,1.500,1.500,1.500,1.505,1.510,1.519,1.527,1.532,1.536,1.536,
        1.535,1.527,1.515,1.477,1.447,1.442,1.454,1.492,1.557,1.571,1.580,1.585,1.584,
        1.581,1.572,1.561,1.476,1.456,1.601,1.774,1.861,1.907,1.919,1.885,1.840,1.818,
        1.783,1.741,1.712,1.698,1.694,1.690,1.697,1.696,1.669,1.679,1.773,1.812,1.811,
        1.809,1.808,1.807,1.806,1.804,1.806,1.808,1.812,1.816,1.820,1.817,1.815,1.812,
        1.809,1.808,1.808,1.808,1.811,1.817,1.823,1.820,1.820};
  //Мнимые части комплексных оптических показателей преломления B1-Аэрозоля
        double [] B1MN = {1.15E-5,1.24E-5,1.33E-5,1.44E-5,1.55E-5,1.67E-5,1.80E-5,1.94E-5,
        2.09E-5,2.25E-5,2.43E-5,2.62E-5,2.82E-5,3.04E-5,3.27E-5,3.53E-5,3.80E-5,4.10E-5,
        4.42E-5,4.76E-5,5.13E-5,5.53E-5,5.96E-5,6.42E-5,6.92E-5,7.46E-5,8.04E-5,8.66E-5,
        9.33E-5,1.01E-4,1.08E-4,1.17E-4,1.26E-4,2.29E-4,4.17E-4,5.62E-4,1.38E-3,2.51E-3,
        4.57E-3,8.32E-3,1.35E-2,1.84E-2,0.0244,0.0288,0.0300,0.0289,0.0274,0.0241,0.0209,
        0.0184,0.0167,0.0156,0.0144,0.0133,0.0124,0.0114,0.0105,0.0097,0.0090,0.00809,
        0.00686,0.00615,0.00568,0.00560,0.00573,0.00598,0.00622,0.00653,0.00695,0.00749,
        0.00806,0.00867,0.00929,0.0101,0.0110,0.0122,0.0136,0.0154,0.0181,0.0210,0.0254,
        0.0311,0.0396,0.0461,0.0474,0.0365,0.0305,0.0279,0.0280,0.0299,0.0326,0.0379,
        0.0510,0.0551,0.0493,0.0464,0.0438,0.0410,0.0392,0.0387,0.0394,0.0406,0.0438,
        0.0483,0.0649,0.0841,0.0970,0.1022,0.1092,0.1211,0.0944,0.0916,0.0646,0.0532,
        0.0398,0.0313,0.0301,0.0389,0.0442,0.0461,0.0478,0.0493,0.0504,0.0668,0.0722,
        0.0777,0.0832,0.1072,0.1091,0.1083,0.1075,0.1055,0.1035,0.1022,0.1048,0.1099,
        0.1176,0.1252,0.1337,0.1422,0.1497,0.1609,0.1722,0.1813,0.2081,0.2390,0.2744,
        0.3150,0.3617};
//Морская соль
  //Длины волн
        double [] SeaSaltLambda = {0.2000,0.2500,0.3000,0.3371,0.4000,0.4880,
        0.5145,0.5500,0.6328,0.6943,0.8600,1.0600,1.3000,1.5360,1.8000,2.0000,2.2500,2.5000,
        2.7000,3.0000,3.2000,3.3923,3.5000,3.7500,4.0000,4.5000,5.0000,5.5000,6.0000,6.2000,
        6.5000,7.2000,7.9000,8.2000,8.5000,8.7000,9.0000,9.2000,9.5000,9.8000,10.000,10.591,
        11.000,11.500,12.500,13.000,14.000,14.800,15.000,16.400,17.200,18.000,18.500,20.000,
        21.300,22.500,25.000,27.000,30.000,35.000,40.000};
  //Действительные части комплексных оптических показателей преломления моской соли
        double [] SeaSaltMN1 = {1.510,1.510,1.510,1.510,1.500,1.500,1.500,1.500,1.490,
        1.490,1.480,1.470,1.470,1.460,1.450,1.450,1.440,1.430,1.400,1.610,1.490,1.480,1.480,
        1.470,1.480,1.490,1.470,1.420,1.410,1.600,1.460,1.420,1.400,1.420,1.480,1.600,1.650,
        1.610,1.580,1.560,1.540,1.500,1.480,1.480,1.420,1.410,1.410,1.430,1.450,1.560,1.740,
        1.780,1.770,1.760,1.760,1.760,1.760,1.770,1.770,1.760,1.740};
  //Мнимые части комплексных оптических показателей преломления моской соли
        double [] SeaSaltMN2 = {1.00E-4,5.00E-6,2.00E-6,4.00E-7,3.00E-8,2.00E-8,1.00E-8,
        1.00E-8,2.00E-8,1.00E-7,3.00E-6,2.00E-4,4.00E-4,6.00E-4,8.00E-4,1.00E-3,2.00E-3,4.00E-3,
        7.00E-3,1.00E-2,3.00E-3,2.30E-3,1.60E-3,1.40E-3,1.40E-3,1.40E-3,2.50E-3,3.60E-3,1.10E-2,
        2.20E-2,5.00E-3,7.00E-3,1.30E-2,2.00E-2,2.60E-2,3.00E-2,2.80E-2,2.60E-2,1.80E-2,1.60E-2,
        1.50E-2,1.40E-2,1.40E-2,1.40E-2,1.60E-2,1.80E-2,2.30E-2,3.00E-2,3.50E-2,9.00E-2,1.20E-1,
        1.30E-1,1.35E-1,1.52E-1,1.65E-1,1.80E-1,2.05E-1,2.75E-1,3.00E-1,5.00E-1,1.00E-0};
//Вода
  //Длины волн
        double [] WateLambda = {0.2000,0.2250,0.2500,0.2750,0.3000,0.3250,0.3500,
        0.3750,0.4000,0.4250,0.4500,0.4750,0.5000,0.5250,0.5500,0.5750,0.6000,0.6250,0.6500,
        0.6750,0.7000,0.7250,0.7500,0.7750,0.8000,0.8250,0.8500,0.8750,0.9000,0.9250,0.9500,
        0.9750,1.00,1.20,1.40,1.60,1.80,2.00,2.20,2.40,2.60,2.65,2.70,2.75,2.80,2.85,2.90,
        2.95,3.00,3.05,3.10,3.15,3.20,3.25,3.30,3.35,3.40,3.45,3.50,3.6,3.7,3.8,3.9,4.0,
        4.1,4.2,4.3,4.4,4.5,4.6,4.7,4.8,4.9,5.0,5.1,5.2,5.3,5.4,5.5,5.6,5.7,5.8,5.9,6.0,
        6.1,6.2,6.3,6.4,6.5,6.6,6.7,6.8,6.9,7.0,7.1,7.2,7.3,7.4,7.5,7.6,7.7,7.8,7.9,8.0,
        8.2,8.4,8.6,8.8,9.0,9.2,9.4,9.6,9.8,10.0,10.5,11.0,11.5,12.0,12.5,13.0,13.5,14.0,
        14.5,15.0,15.5,16.0,16.5,17.0,17.5,18.0,18.5,19.0,19.5,20.0,21.0,22,23,24,25,26,
        27,28,29,30,32,34,36,38,40};
  //Действительные части комплексных оптических показателей преломления воды
        double [] WaterMN1 = {1.396,1.373,1.362,1.354,1.349,1.346,1.343,1.341,1.339,
        1.338,1.337,1.336,1.335,1.334,1.333,1.333,1.332,1.332,1.331,1.331,1.331,1.330,
        1.330,1.330,1.329,1.329,1.329,1.328,1.328,1.328,1.327,1.327,1.327,1.324,1.321,
        1.317,1.312,1.306,1.296,1.279,1.242,1.219,1.188,1.157,1.142,1.149,1.201,1.292,
        1.371,1.426,1.467,1.483,1.478,1.467,1.450,1.432,1.420,1.410,1.400,1.385,1.374,
        1.364,1.357,1.351,1.346,1.342,1.338,1.334,1.332,1.330,1.330,1.330,1.328,1.325,
        1.322,1.317,1.312,1.305,1.298,1.289,1.277,1.262,1.248,1.265,1.319,1.363,1.357,
        1.347,1.339,1.334,1.329,1.324,1.321,1.317,1.314,1.312,1.309,1.307,1.304,1.302,
        1.299,1.297,1.294,1.291,1.286,1.281,1.275,1.269,1.262,1.255,1.247,1.239,1.229,
        1.218,1.185,1.153,1.126,1.111,1.123,1.146,1.177,1.210,1.241,1.270,1.297,1.325,
        1.351,1.376,1.401,1.423,1.443,1.461,1.476,1.480,1.487,1.500,1.511,1.521,1.531,
        1.539,1.545,1.549,1.551,1.551,1.546,1.536,1.527,1.522,1.519};
  //Мнимые части комплексных оптических показателей преломления воды
        double [] WaterMN2 = {1.10E-7,4.90E-8,3.35E-8,2.35E-8,1.60E-8,1.08E-8,6.50E-9,
        3.50E-9,1.86E-9,1.30E-9,1.02E-9,9.35E-10,1.00E-9,1.32E-9,1.96E-9,3.60E-9,1.09E-8,
        1.39E-8,1.64E-8,2.23E-8,3.35E-8,9.15E-8,1.56E-7,1.48E-7,1.25E-7,1.82E-7,2.93E-7,
        3.91E-7,4.86E-7,1.06E-6,2.93E-6,3.48E-6,2.89E-6,9.89E-6,1.38E-4,8.55E-5,1.15E-4,
        1.10E-3,2.89E-4,9.56E-4,3.17E-3,6.70E-3,0.019,0.059,0.115,0.185,0.268,0.298,0.272,
        0.240,0.192,0.135,0.0924,0.0610,0.0368,0.0261,0.0195,0.0132,0.0094,0.00515,0.00360,
        0.00340,0.00380,0.00460,0.00562,0.00688,0.00845,0.0103,0.0134,0.0147,0.0147,0.0150,
        0.0137,0.0124,0.0111,0.0101,0.0098,0.0103,0.0116,0.0142,0.0203,0.0330,0.0622,0.107,
        0.131,0.0880,0.0570,0.0449,0.0392,0.0356,0.0337,0.0327,0.0322,0.0320,0.0320,0.0321,
        0.0322,0.0324,0.0326,0.0328,0.0331,0.0335,0.0339,0.0343,0.0351,0.0361,0.0372,0.0385,
        0.0399,0.0415,0.0433,0.0454,0.0479,0.0508,0.0662,0.0968,0.142,0.199,0.259,0.305,
        0.343,0.370,0.388,0.402,0.414,0.422,0.428,0.429,0.429,0.426,0.421,0.414,0.404,
        0.393,0.382,0.373,0.367,0.361,0.356,0.350,0.344,0.338,0.333,0.328,0.324,0.329,
        0.343,0.361,0.385};
        var refMed = 1;
////////////////////////////////////////////////////////////////////////////////
            return new ResultData()
            {
                 diffractionParametr = 2 * Math.PI * rangeMin * refMed / wavelength,

            };
        }
    }
}
