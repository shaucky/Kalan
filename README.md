[![License: MIT](https://img.shields.io/badge/License-MIT-yellow.svg)](https://github.com/shaucky/Kalan/blob/main/LICENSE)
[![.NET Version](https://img.shields.io/badge/.NET-Standard_2.0+-mediumpurple.svg)](https://dotnet.microsoft.com)
[![Unity Version](https://img.shields.io/badge/Unity-2018.1+-silver.svg)](https://unity.com/)

# Kalan
Kalan（卡兰）是一个面向《赛尔号》HTML5端（http://seerh5.61.com ）数据的游戏图鉴工具库。它基于《赛尔号》HTML5端的游戏数据格式，提供了一套解析数据的工具，能够帮助开发者构建游戏图鉴工具。

## 关于Kalan
Kalan基于.NET Standard 2.0开发，能够方便地集成到.NET项目和Unity项目中，理论上有良好的向前兼容性。

Kalan通过在联网状态下比对客户端和服务器端的数据版本，确保获取最新的数据，并将这些数据保存在本地。一方面，这可以减少网络请求频率，另一方面，这能够支持脱机使用。

基于可获取的数据，Kalan可以解析出精灵、技能、皮肤等详细数据，并反序列化为可由API访问的形式。Kalan是一个库，这意味着任何开发者可以通过在项目中嵌入Kalan，轻松构建精灵图鉴、技能图鉴、皮肤图鉴等工具。

## 依赖项
* [Newtonsoft.Json](https://www.newtonsoft.com/json) 13.0

## 开发者文档
to do

## 许可证
Kalan使用MIT许可证，使用Kalan需要注明项目原贡献者。详情请参阅[LICENSE](https://github.com/shaucky/Kalan/blob/main/LICENSE)文件。

## 贡献
Kalan目前处于开发阶段。待项目稳定后，欢迎开发者参与到Kalan的贡献中来。

## 为什么叫Kalan
Kalan这个名字源自于《赛尔号》探索的第二个星系，卡兰星系（Kalan Galaxy）。

同时，Kalan的数据格式基于《赛尔号》HTML5端，它也是《赛尔号》的第二个前端/客户端。不仅如此，开发Kalan使用的C#，也是开发者掌握的第二门编程语言。

《赛尔号》在十余年的运营中，积累了大量的游戏数据，这些丰富的游戏数据对玩家来说不止是乐趣和策略，更是情怀和记忆。希望Kalan，能够承载我们更多的故事。