# XWeeklyReport
个人周报、待办事项、提醒磁贴和管理程序的集合。

## 一、项目说明：
1. IDE：Visual Studio 2017。
2. Net Framework版本：4.5。
3. 开发语言：C#。
4. 数据库：SQLite。轻型数据库，无需搭建环境及部署，以文件的形式存在于本地，便携，方便分发。
5. 管理项目“XWRManagement”、待办事项项目“XToDoList”和提醒磁贴项目“XReminderTile”均会生成到个人周报项目“XWeeklyReport”的“\bin\Debug”目录中。

## 二、文件说明：
### 数据库文件：DB-Empty.db
1. 此文件为空数据库文件，里面有所有的表结构，没有任何数据。
2. 此文件在“\XWeeklyReport\bin\Debug\DB”目录内。
3. 开发、调试或使用时需要把此文件重命名为“DB.db”。
> 注意：建议复制此文件的副本再把副本进行重命名，保留此空数据库文件，方便分发和传播时不泄露私人数据。

### 配置文件：Settings.ini
1. 此文件为应用程序的配置文件，记录程序运行时的相关配置项。
2. 此文件在“XWeeklyReport\bin\Debug”目录内。

### 图标文件
1. 存放在“\Images\Logo”目录内。
2. 有PSD原文件和生成的ICO文件。
3. ICO文件的大小为256*256，透明背景。
4. 部分素材取自互联网，如有侵权，请使用站内信联系本人。
