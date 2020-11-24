# KC.Template.BackgroundService.Net5
KC.Template.BackgroundService.Net5是基于.Net5、Dapper、Autofac等的后台任务快速开发模板；

# 功能介绍

1、实现基于BackgroundService的后台任务快速开发。

# 分层简介
| 层 | 说明 |
| :---------------- | --------------: |
| 1_Common          | 公共层     |
| 2_Infrastructure  | 基础设施层   | 
| 3_Domain          | 领域层       | 
| 4_Service         | 服务层     | 
| 5_App             | 应用层     |


# 使用步骤
1、从github上clone <a href="https://github.com/KongCon/KC.Template.BackgroundService.Net5">KC.Template.BackgroundService.Net5.git</a>
```csharp
git clone https://github.com/KongCon/KC.Template.BackgroundService.Net5.git
```
2、使用VS打开项目KC.Template.BackgroundService，并编译通过

3、从github上clone <a href="https://github.com/KongCon/KC.Tools">KC.Tools</a>
```csharp
git clone https://github.com/KongCon/KC.Tools.git
```
4.使用VS打开项目KC.Tools，并编译通过

5.运行KC.Tools的SolutionRename控制台程序，修改模板项目为自己的项目名称

6.重新运行编译新命名的项目

7.新建数据库，执行db文件夹下的示例数据脚本

8.修改数据库连接

9.运行项目即可
