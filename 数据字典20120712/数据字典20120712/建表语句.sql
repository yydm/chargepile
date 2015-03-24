
--删除表 角色
ALTER TABLE SM_ROLE
  DROP PRIMARY KEY CASCADE;
	DROP TABLE SM_ROLE CASCADE CONSTRAINTS;

--
-- 创建表 角色
--
CREATE TABLE SM_ROLE
(
	ROLEID --- VARCHAR2(36) not null , --角色Id(主键)	
	  APPID--- VARCHAR2(36)  null , --应用系统Id
	  ROLENAME--- VARCHAR2(64)  null , --角色名称
	  ROLEDESC--- VARCHAR2(256)  null , --角色描述
	  ROLENO--- NUMBER(10,0)  null , --角色编号
	  STAGRADE--- NUMBER(10,0)  null , --岗位级别
	  CREATEDT--- DATE  null , --创建时间
	  UPDATEDT--- DATE  null , --更新时间 
	 constraint PK_SM_ROLE primary key (ROLEID  )
);
--添加表角色的注释
COMMENT ON TABLE SM_ROLE IS '角色';
--添加表角色的列注释

COMMENT ON COLUMN SM_ROLE.ROLEID IS '角色Id    ';

COMMENT ON COLUMN SM_ROLE.APPID IS '应用系统Id    ,采用应用系统英文缩写，系统唯一 ';

COMMENT ON COLUMN SM_ROLE.ROLENAME IS '角色名称    ';

COMMENT ON COLUMN SM_ROLE.ROLEDESC IS '角色描述    ,角色描述。 ';

COMMENT ON COLUMN SM_ROLE.ROLENO IS '角色编号    ,外部集成使用 ';

COMMENT ON COLUMN SM_ROLE.STAGRADE IS '岗位级别    ,类型,枚举类型:1 高层岗;2 中层岗;3 执行岗; ';

COMMENT ON COLUMN SM_ROLE.CREATEDT IS '创建时间    ';

COMMENT ON COLUMN SM_ROLE.UPDATEDT IS '更新时间    ';
-- 外键索引

--删除表 资源菜单信息表
ALTER TABLE SM_RESMENU
  DROP PRIMARY KEY CASCADE;
	DROP TABLE SM_RESMENU CASCADE CONSTRAINTS;

--
-- 创建表 资源菜单信息表
--
CREATE TABLE SM_RESMENU
(
	RESID --- VARCHAR2(36) not null , --菜单Id(主键)	
	  PARENTID--- VARCHAR2(36)  null , --上级菜单
	  APPID--- VARCHAR2(36)  null , --应用系统Id
	  CAPTION--- VARCHAR2(256)  null , --菜单标题
	  TOOLTIP--- VARCHAR2(256)  null , --菜单描述信息
	  HREF--- VARCHAR2(256)  null , --菜单的链接地址
	  HREFTARGET--- VARCHAR2(64)  null , --目标窗口
	  ICONCLS--- VARCHAR2(256)  null , --菜单图标样式
	  LARGERICONCLS--- VARCHAR2(256)  null , --大图标样式
	  ITEMCLS--- VARCHAR2(256)  null , --菜单项样式
	  OVERCLS--- VARCHAR2(256)  null , --悬停样式
	  NODEID--- VARCHAR2(256)  null , --菜单节点Id
	  SORTNO--- NUMBER(10,0)  null , --排序序号
	  NAVTYPE--- VARCHAR2(32)  null , --导航模式
	  REMARK--- VARCHAR2(256)  null , --备注
	  LEVEL_ID--- NUMBER(10,0)  null , --层次级别
	  ISTABS--- NUMBER(1,0)  null , --选项卡式显示
	  HOSTTYPE--- VARCHAR2(32)  null , --客户区类型
	  ASSEMBLY--- VARCHAR2(256)  null , --程序集
	  TYPEFULLNAME--- VARCHAR2(256)  null , --对应类型全名
	  SHORTCUTKEY--- VARCHAR2(64)  null , --快捷键
	  EVENTHANDLE--- VARCHAR2(64)  null , --事件处理方法名
	  HOSTKEY--- VARCHAR2(32)  null , --关键字
	  UISTYLE--- VARCHAR2(32)  null , --UI样式
	  CREATEDT--- DATE  null , --创建时间
	  UPDATEDT--- DATE  null , --更新时间 
	 constraint PK_SM_RESMENU primary key (RESID  )
);
--添加表资源菜单信息表的注释
COMMENT ON TABLE SM_RESMENU IS '资源菜单信息表';
--添加表资源菜单信息表的列注释

COMMENT ON COLUMN SM_RESMENU.RESID IS '菜单Id    ';

COMMENT ON COLUMN SM_RESMENU.PARENTID IS '上级菜单    ,菜单Id ';

COMMENT ON COLUMN SM_RESMENU.APPID IS '应用系统Id    ,采用应用系统英文缩写，系统唯一 ';

COMMENT ON COLUMN SM_RESMENU.CAPTION IS '菜单标题    ';

COMMENT ON COLUMN SM_RESMENU.TOOLTIP IS '菜单描述信息    ';

COMMENT ON COLUMN SM_RESMENU.HREF IS '菜单的链接地址    ';

COMMENT ON COLUMN SM_RESMENU.HREFTARGET IS '目标窗口    ';

COMMENT ON COLUMN SM_RESMENU.ICONCLS IS '菜单图标样式    ';

COMMENT ON COLUMN SM_RESMENU.LARGERICONCLS IS '大图标样式    ';

COMMENT ON COLUMN SM_RESMENU.ITEMCLS IS '菜单项样式    ';

COMMENT ON COLUMN SM_RESMENU.OVERCLS IS '悬停样式    ';

COMMENT ON COLUMN SM_RESMENU.NODEID IS '菜单节点Id    ';

COMMENT ON COLUMN SM_RESMENU.SORTNO IS '排序序号    ,在菜单同一级别中的排序号 ';

COMMENT ON COLUMN SM_RESMENU.NAVTYPE IS '导航模式    ,枚举类型：
OnlyLeft：只在左边导航（默认)
OnlyTop：只在顶部导航
Both：同时在顶部和左边同时显示 ';

COMMENT ON COLUMN SM_RESMENU.REMARK IS '备注    ';

COMMENT ON COLUMN SM_RESMENU.LEVEL_ID IS '层次级别    ';

COMMENT ON COLUMN SM_RESMENU.ISTABS IS '选项卡式显示    ';

COMMENT ON COLUMN SM_RESMENU.HOSTTYPE IS '客户区类型    ,Ribbon(用户模块，一级菜单）、Groups（二级菜单）、PopupMenum（子菜单）、ControlContainer（菜单容器）、Button（菜单条）、 ';

COMMENT ON COLUMN SM_RESMENU.ASSEMBLY IS '程序集    ';

COMMENT ON COLUMN SM_RESMENU.TYPEFULLNAME IS '对应类型全名    ';

COMMENT ON COLUMN SM_RESMENU.SHORTCUTKEY IS '快捷键    ';

COMMENT ON COLUMN SM_RESMENU.EVENTHANDLE IS '事件处理方法名    ';

COMMENT ON COLUMN SM_RESMENU.HOSTKEY IS '关键字    ';

COMMENT ON COLUMN SM_RESMENU.UISTYLE IS 'UI样式    ,CS:winform界面
BS:内嵌BS页面 ';

COMMENT ON COLUMN SM_RESMENU.CREATEDT IS '创建时间    ';

COMMENT ON COLUMN SM_RESMENU.UPDATEDT IS '更新时间    ';
-- 外键索引

--删除表 用户
ALTER TABLE SM_USER
  DROP PRIMARY KEY CASCADE;
	DROP TABLE SM_USER CASCADE CONSTRAINTS;

--
-- 创建表 用户
--
CREATE TABLE SM_USER
(
	USERID --- VARCHAR2(36) not null , --用户ID(主键)	
	  EMP_NO--- VARCHAR2(36)  null , --人员编号
	  LOGINNAME--- VARCHAR2(36)  null , --系统登录名
	  PWD--- VARCHAR2(64)  null , --密码
	  IP--- VARCHAR2(4000)  null , --绑定的IP
	  MAC--- VARCHAR2(32)  null , --绑定的物理地址
	  CUR_STATUS_CODE--- VARCHAR2(32)  null , --当前状态
	  PWD_REMIND_TIME--- DATE  null , --密码强度提醒时间
	  LOCK_TIME--- DATE  null , --锁定时间
	  PLAN_UNLOCK_TIME--- DATE  null , --计划解锁时间
	  UNLOCK_TIME--- DATE  null , --实际解锁时间
	  LOCK_IP--- VARCHAR2(32)  null , --锁定IP
	  AUTO_UNLOCK_FLAG--- NUMBER(1,0)  null , --自动解锁标志
	  LOCK_REASON--- VARCHAR2(256)  null , --锁定原因
	  UNLOCK_EMP_NO--- VARCHAR2(16)  null , --解锁人员
	  SID--- VARCHAR2(64)  null , --安全验证码
	  CREATEDT--- DATE  null , --创建时间
	  UPDATEDT--- DATE  null , --更新时间 
	 constraint PK_SM_USER primary key (USERID  )
);
--添加表用户的注释
COMMENT ON TABLE SM_USER IS '用户';
--添加表用户的列注释

COMMENT ON COLUMN SM_USER.USERID IS '用户ID    ';

COMMENT ON COLUMN SM_USER.EMP_NO IS '人员编号    ,本实体记录的唯一标识。 ';

COMMENT ON COLUMN SM_USER.LOGINNAME IS '系统登录名    ,系统用户名 ';

COMMENT ON COLUMN SM_USER.PWD IS '密码    ,用户口令，采用密文存储。 ';

COMMENT ON COLUMN SM_USER.IP IS '绑定的IP    ,用户绑定的IP地址。可以是多个具体的IP地址，也可以是通用IP地址（如10.152.109.*） ';

COMMENT ON COLUMN SM_USER.MAC IS '绑定的物理地址    ,用户绑定的计算机物理地址。网卡适配器的地址（即MAC地址）。 ';

COMMENT ON COLUMN SM_USER.CUR_STATUS_CODE IS '当前状态    ,系统用户的状态，包括：启用、禁用、删除。
01 正常、02 禁用 、03 删除、04 锁定。 ';

COMMENT ON COLUMN SM_USER.PWD_REMIND_TIME IS '密码强度提醒时间    ,记录密码强度提醒时间，用于密码强度检测 ';

COMMENT ON COLUMN SM_USER.LOCK_TIME IS '锁定时间    ,记录锁定的时间。 ';

COMMENT ON COLUMN SM_USER.PLAN_UNLOCK_TIME IS '计划解锁时间    ,计划解锁时间。通过锁定时限计算出来，计划解锁时间＝锁定时间＋锁定时限。 ';

COMMENT ON COLUMN SM_USER.UNLOCK_TIME IS '实际解锁时间    ,实际的解锁时间 ';

COMMENT ON COLUMN SM_USER.LOCK_IP IS '锁定IP    ,系统用户被锁定时，客户端使用的IP地址。 ';

COMMENT ON COLUMN SM_USER.AUTO_UNLOCK_FLAG IS '自动解锁标志    ,是否自动解锁 ';

COMMENT ON COLUMN SM_USER.LOCK_REASON IS '锁定原因    ,锁定原因的说明。 ';

COMMENT ON COLUMN SM_USER.UNLOCK_EMP_NO IS '解锁人员    ,记录解锁的人员 ';

COMMENT ON COLUMN SM_USER.SID IS '安全验证码    ,系统集成使用 ';

COMMENT ON COLUMN SM_USER.CREATEDT IS '创建时间    ';

COMMENT ON COLUMN SM_USER.UPDATEDT IS '更新时间    ';
-- 外键索引

--删除表 权限定义
ALTER TABLE SM_PRIV
  DROP PRIMARY KEY CASCADE;
	DROP TABLE SM_PRIV CASCADE CONSTRAINTS;

--
-- 创建表 权限定义
--
CREATE TABLE SM_PRIV
(
	PRIVID --- VARCHAR2(36) not null , --权限标识(主键)	
	  PRIVNAME--- VARCHAR2(256)  null , --权限名称 
	 constraint PK_SM_PRIV primary key (PRIVID  )
);
--添加表权限定义的注释
COMMENT ON TABLE SM_PRIV IS '权限定义';
--添加表权限定义的列注释

COMMENT ON COLUMN SM_PRIV.PRIVID IS '权限标识    ,本实体记录的唯一标识。 ';

COMMENT ON COLUMN SM_PRIV.PRIVNAME IS '权限名称    ,权限名称。 ';
-- 外键索引

--删除表 用户角色关系
ALTER TABLE SM_USEROLES
  DROP PRIMARY KEY CASCADE;
	DROP TABLE SM_USEROLES CASCADE CONSTRAINTS;

--
-- 创建表 用户角色关系
--
CREATE TABLE SM_USEROLES
(
	ROLEID --- VARCHAR2(36) not null , --角色Id(主键)	
	LOGINNAME --- VARCHAR2(36) not null , --系统登录名(主键)	 
	 constraint PK_SM_USEROLES primary key (ROLEID   , LOGINNAME  )
);
--添加表用户角色关系的注释
COMMENT ON TABLE SM_USEROLES IS '用户角色关系';
--添加表用户角色关系的列注释

COMMENT ON COLUMN SM_USEROLES.ROLEID IS '角色Id    ';

COMMENT ON COLUMN SM_USEROLES.LOGINNAME IS '系统登录名    ,系统用户名 ';
-- 外键索引

--删除表 角色资源授权
ALTER TABLE SM_ROLERESPRIV
  DROP PRIMARY KEY CASCADE;
	DROP TABLE SM_ROLERESPRIV CASCADE CONSTRAINTS;

--
-- 创建表 角色资源授权
--
CREATE TABLE SM_ROLERESPRIV
(
	ROLEID --- VARCHAR2(36) not null , --角色Id(主键)	
	PRIVID --- VARCHAR2(36) not null , --权限标识(主键)	
	RESID --- VARCHAR2(36) not null , --菜单Id(主键)	 
	 constraint PK_SM_ROLERESPRIV primary key (ROLEID   , PRIVID   , RESID  )
);
--添加表角色资源授权的注释
COMMENT ON TABLE SM_ROLERESPRIV IS '角色资源授权';
--添加表角色资源授权的列注释

COMMENT ON COLUMN SM_ROLERESPRIV.ROLEID IS '角色Id    ';

COMMENT ON COLUMN SM_ROLERESPRIV.PRIVID IS '权限标识    ,本实体记录的唯一标识。 ';

COMMENT ON COLUMN SM_ROLERESPRIV.RESID IS '菜单Id    ';
-- 外键索引

--删除表 应用系统
ALTER TABLE SM_APPLICATION
  DROP PRIMARY KEY CASCADE;
	DROP TABLE SM_APPLICATION CASCADE CONSTRAINTS;

--
-- 创建表 应用系统
--
CREATE TABLE SM_APPLICATION
(
	APPID --- VARCHAR2(36) not null , --应用系统Id(主键)	
	  APPNAME--- VARCHAR2(64)  null , --应用系统名称
	  APPDESC--- VARCHAR2(64)  null , --应用系统描述
	  AB_NAME--- VARCHAR2(64)  null , --系统简称
	  ICONCLS--- VARCHAR2(64)  null , --应用图标样式
	  SSO_URL--- VARCHAR2(256)  null , --单点登录URL
	  APPKEY--- VARCHAR2(32)  null , --应用系统标识
	  SORTNO--- NUMBER(10,0)  null , --排序序号
	  CREATEDT--- DATE  null , --创建时间
	  UPDATEDT--- DATE  null , --更新时间 
	 constraint PK_SM_APPLICATION primary key (APPID  )
);
--添加表应用系统的注释
COMMENT ON TABLE SM_APPLICATION IS '应用系统';
--添加表应用系统的列注释

COMMENT ON COLUMN SM_APPLICATION.APPID IS '应用系统Id    ,采用应用系统英文缩写，系统唯一 ';

COMMENT ON COLUMN SM_APPLICATION.APPNAME IS '应用系统名称    ';

COMMENT ON COLUMN SM_APPLICATION.APPDESC IS '应用系统描述    ';

COMMENT ON COLUMN SM_APPLICATION.AB_NAME IS '系统简称    ';

COMMENT ON COLUMN SM_APPLICATION.ICONCLS IS '应用图标样式    ';

COMMENT ON COLUMN SM_APPLICATION.SSO_URL IS '单点登录URL    ';

COMMENT ON COLUMN SM_APPLICATION.APPKEY IS '应用系统标识    ,应用系统标识，应用系统英文缩写 ';

COMMENT ON COLUMN SM_APPLICATION.SORTNO IS '排序序号    ,在菜单同一级别中的排序号 ';

COMMENT ON COLUMN SM_APPLICATION.CREATEDT IS '创建时间    ';

COMMENT ON COLUMN SM_APPLICATION.UPDATEDT IS '更新时间    ';
-- 外键索引

--删除表 部门
ALTER TABLE ORG_DEP
  DROP PRIMARY KEY CASCADE;
	DROP TABLE ORG_DEP CASCADE CONSTRAINTS;

--
-- 创建表 部门
--
CREATE TABLE ORG_DEP
(
	DEPT_ID --- VARCHAR2(36) not null , --部门编号(主键)	
	  PARENTID--- VARCHAR2(36)  null , --上级部门
	  AB_NAME--- VARCHAR2(256)  null , --简称
	  EMP_NAME--- VARCHAR2(32)  null , --名称
	  DISP_SN--- VARCHAR2(36)  null , --显示序号
	  TREENO--- VARCHAR2(64)  null , --树节点编号
	  CREATEDT--- DATE  null , --创建时间
	  UPDATEDT--- DATE  null , --更新时间 
	 constraint PK_ORG_DEP primary key (DEPT_ID  )
);
--添加表部门的注释
COMMENT ON TABLE ORG_DEP IS '部门';
--添加表部门的列注释

COMMENT ON COLUMN ORG_DEP.DEPT_ID IS '部门编号    ,本实体记录的唯一标识，创建部门的唯一编码。 ';

COMMENT ON COLUMN ORG_DEP.PARENTID IS '上级部门    ,本实体记录的唯一标识，创建部门的唯一编码。 ';

COMMENT ON COLUMN ORG_DEP.AB_NAME IS '简称    ,部门名称的缩写。 ';

COMMENT ON COLUMN ORG_DEP.EMP_NAME IS '名称    ';

COMMENT ON COLUMN ORG_DEP.DISP_SN IS '显示序号    ,部门树形展现时的显示顺序号。 ';

COMMENT ON COLUMN ORG_DEP.TREENO IS '树节点编号    ,集成CCFlow使用 ';

COMMENT ON COLUMN ORG_DEP.CREATEDT IS '创建时间    ';

COMMENT ON COLUMN ORG_DEP.UPDATEDT IS '更新时间    ';
-- 外键索引

--删除表 员工
ALTER TABLE ORG_EMP
  DROP PRIMARY KEY CASCADE;
	DROP TABLE ORG_EMP CASCADE CONSTRAINTS;

--
-- 创建表 员工
--
CREATE TABLE ORG_EMP
(
	EMPID --- VARCHAR2(36) not null , --员工ID(主键)	
	  DEPT_ID--- VARCHAR2(36)  null , --部门编号
	  EMP_NO--- VARCHAR2(36)  null , --人员编号
	  EMP_NAME--- VARCHAR2(32)  null , --名称
	  GENDER--- VARCHAR2(32)  null , --性别
	  PHOTO--- LONG RAW  null , --相片
	  POS_NAME--- VARCHAR2(256)  null , --职位
	  POSITION--- VARCHAR2(32)  null , --岗位
	  TECH_LEVEL_CODE--- VARCHAR2(32)  null , --技术等级
	  BIRTH_YMD--- DATE  null , --出生年月
	  DEGREE_CODE--- VARCHAR2(32)  null , --文化程度
	  MOBLILE--- VARCHAR2(32)  null , --手机号码
	  OFFICE_TEL_NO--- VARCHAR2(32)  null , --办公电话
	  ON_POS_FLAG--- NUMBER(1,0)  null , --在岗标志
	  PROFESSION--- VARCHAR2(16)  null , --专业
	  JOIN_DATE--- DATE  null , --工作日期
	  TITEL--- VARCHAR2(256)  null , --职称
	  POLITICAL_STATUS_CODE--- VARCHAR2(32)  null , --政治面貌
	  TITEL_LEVEL_CODE--- VARCHAR2(32)  null , --职称级别
	  REMARK--- VARCHAR2(256)  null , --备注
	  DISP_SN--- VARCHAR2(36)  null , --显示序号
	  CREATEDT--- DATE  null , --创建时间
	  UPDATEDT--- DATE  null , --更新时间 
	 constraint PK_ORG_EMP primary key (EMPID  )
);
--添加表员工的注释
COMMENT ON TABLE ORG_EMP IS '员工';
--添加表员工的列注释

COMMENT ON COLUMN ORG_EMP.EMPID IS '员工ID    ';

COMMENT ON COLUMN ORG_EMP.DEPT_ID IS '部门编号    ,本实体记录的唯一标识，创建部门的唯一编码。 ';

COMMENT ON COLUMN ORG_EMP.EMP_NO IS '人员编号    ,本实体记录的唯一标识。 ';

COMMENT ON COLUMN ORG_EMP.EMP_NAME IS '名称    ';

COMMENT ON COLUMN ORG_EMP.GENDER IS '性别    ,性别。01 男、02 女 ';

COMMENT ON COLUMN ORG_EMP.PHOTO IS '相片    ,人员的相片。 ';

COMMENT ON COLUMN ORG_EMP.POS_NAME IS '职位    ,所在职位名称。 ';

COMMENT ON COLUMN ORG_EMP.POSITION IS '岗位    ,人员所在岗位代码。 ';

COMMENT ON COLUMN ORG_EMP.TECH_LEVEL_CODE IS '技术等级    ,人员的技术等级代码。 ';

COMMENT ON COLUMN ORG_EMP.BIRTH_YMD IS '出生年月    ,出生年月日 ';

COMMENT ON COLUMN ORG_EMP.DEGREE_CODE IS '文化程度    ,文化程度。01 专科、02 本科、03 研究生、04 博士、05 博士后。 ';

COMMENT ON COLUMN ORG_EMP.MOBLILE IS '手机号码    ,人员联系手机号码。 ';

COMMENT ON COLUMN ORG_EMP.OFFICE_TEL_NO IS '办公电话    ,办公室电话号码 ';

COMMENT ON COLUMN ORG_EMP.ON_POS_FLAG IS '在岗标志    ,是否在职标志。 ';

COMMENT ON COLUMN ORG_EMP.PROFESSION IS '专业    ,技术专业说明。 ';

COMMENT ON COLUMN ORG_EMP.JOIN_DATE IS '工作日期    ,参加工作开始日期。 ';

COMMENT ON COLUMN ORG_EMP.TITEL IS '职称    ,个人职称说明。 ';

COMMENT ON COLUMN ORG_EMP.POLITICAL_STATUS_CODE IS '政治面貌    ,政治面貌，如
01 普通
02 团员
03 党员 ';

COMMENT ON COLUMN ORG_EMP.TITEL_LEVEL_CODE IS '职称级别    ,职称级别，如
01 初级
02 中级
03 高级及以上 ';

COMMENT ON COLUMN ORG_EMP.REMARK IS '备注    ';

COMMENT ON COLUMN ORG_EMP.DISP_SN IS '显示序号    ,部门树形展现时的显示顺序号。 ';

COMMENT ON COLUMN ORG_EMP.CREATEDT IS '创建时间    ';

COMMENT ON COLUMN ORG_EMP.UPDATEDT IS '更新时间    ';
-- 外键索引

--删除表 系统编码表
ALTER TABLE SYS_CODE
  DROP PRIMARY KEY CASCADE;
	DROP TABLE SYS_CODE CASCADE CONSTRAINTS;

--
-- 创建表 系统编码表
--
CREATE TABLE SYS_CODE
(
	ID --- VARCHAR2(36) not null , --唯一Id(主键)	
	  PARENTID--- VARCHAR2(36)  null , --上级编码
	  APPID--- VARCHAR2(36)  null , --应用系统Id
	  CODE--- VARCHAR2(32)  null , --基础编码
	  CODENAME--- VARCHAR2(16)  null , --编码名称
	  DESCRIPTION--- VARCHAR2(256)  null , --编码说明
	  SORTNO--- NUMBER(10,0)  null , --排序序号
	  CREATEDT--- DATE  null , --创建时间
	  UPDATEDT--- DATE  null , --更新时间 
	 constraint PK_SYS_CODE primary key (ID  )
);
--添加表系统编码表的注释
COMMENT ON TABLE SYS_CODE IS '系统编码表';
--添加表系统编码表的列注释

COMMENT ON COLUMN SYS_CODE.ID IS '唯一Id    ';

COMMENT ON COLUMN SYS_CODE.PARENTID IS '上级编码    ,唯一Id ';

COMMENT ON COLUMN SYS_CODE.APPID IS '应用系统Id    ,采用应用系统英文缩写，系统唯一 ';

COMMENT ON COLUMN SYS_CODE.CODE IS '基础编码    ';

COMMENT ON COLUMN SYS_CODE.CODENAME IS '编码名称    ';

COMMENT ON COLUMN SYS_CODE.DESCRIPTION IS '编码说明    ';

COMMENT ON COLUMN SYS_CODE.SORTNO IS '排序序号    ,在菜单同一级别中的排序号 ';

COMMENT ON COLUMN SYS_CODE.CREATEDT IS '创建时间    ';

COMMENT ON COLUMN SYS_CODE.UPDATEDT IS '更新时间    ';
-- 外键索引

--删除表 系统日志表
ALTER TABLE SYS_LOG
  DROP PRIMARY KEY CASCADE;
	DROP TABLE SYS_LOG CASCADE CONSTRAINTS;

--
-- 创建表 系统日志表
--
CREATE TABLE SYS_LOG
(
	LOGID --- VARCHAR2(36) not null , --记录ID(主键)	
	  APPID--- VARCHAR2(36)  null , --应用系统Id
	  LOGDATE--- DATE  null , --记录时间
	  APPLICATION--- VARCHAR2(64)  null , --应用程序
	  LOGLEVEL--- VARCHAR2(32)  null , --日志级别
	  LOGGER--- VARCHAR2(256)  null , --日志记录源
	  MESSAGE--- VARCHAR2(1000)  null , --日志消息
	  LOGEXCEPTION--- CLOB  null , --异常
	  TAGSTRING--- VARCHAR2(256)  null , --标签字符串
	  TAGTEXT--- VARCHAR2(1000)  null , --附加文本
	  TAG--- NUMBER(10,0)  null , --附加标签
	  CREATEDT--- DATE  null , --创建时间
	  UPDATEDT--- DATE  null , --更新时间 
	 constraint PK_SYS_LOG primary key (LOGID  )
);
--添加表系统日志表的注释
COMMENT ON TABLE SYS_LOG IS '系统日志表';
--添加表系统日志表的列注释

COMMENT ON COLUMN SYS_LOG.LOGID IS '记录ID    ';

COMMENT ON COLUMN SYS_LOG.APPID IS '应用系统Id    ,采用应用系统英文缩写，系统唯一 ';

COMMENT ON COLUMN SYS_LOG.LOGDATE IS '记录时间    ';

COMMENT ON COLUMN SYS_LOG.APPLICATION IS '应用程序    ';

COMMENT ON COLUMN SYS_LOG.LOGLEVEL IS '日志级别    ,Info
Warn
Error
Fatal ';

COMMENT ON COLUMN SYS_LOG.LOGGER IS '日志记录源    ';

COMMENT ON COLUMN SYS_LOG.MESSAGE IS '日志消息    ';

COMMENT ON COLUMN SYS_LOG.LOGEXCEPTION IS '异常    ';

COMMENT ON COLUMN SYS_LOG.TAGSTRING IS '标签字符串    ';

COMMENT ON COLUMN SYS_LOG.TAGTEXT IS '附加文本    ';

COMMENT ON COLUMN SYS_LOG.TAG IS '附加标签    ';

COMMENT ON COLUMN SYS_LOG.CREATEDT IS '创建时间    ';

COMMENT ON COLUMN SYS_LOG.UPDATEDT IS '更新时间    ';
-- 外键索引

--删除表 用户应用桌面配置表
ALTER TABLE SYS_USERAPPDESKCFG
  DROP PRIMARY KEY CASCADE;
	DROP TABLE SYS_USERAPPDESKCFG CASCADE CONSTRAINTS;

--
-- 创建表 用户应用桌面配置表
--
CREATE TABLE SYS_USERAPPDESKCFG
(
	PARTKEY --- VARCHAR2(64) not null , --部件名称(主键)	
	LOGINNAME --- VARCHAR2(36) not null , --系统登录名(主键)	
	  TITLE--- VARCHAR2(64)  null , --部件标题
	  URL--- VARCHAR2(256)  null , --部件Url
	  MOREURL--- VARCHAR2(256)  null , --更多Url
	  COLUMNINDEX--- NUMBER(10,0)  null , --列索引
	  ROWINDEX--- NUMBER(10,0)  null , --行索引
	  REFID--- VARCHAR2(64)  null , --引用Id
	  ORGINDEX--- NUMBER(10,0)  null , --原始索引
	  CREATEDT--- DATE  null , --创建时间
	  UPDATEDT--- DATE  null , --更新时间 
	 constraint PK_SYS_USERAPPDESKCFG primary key (PARTKEY   , LOGINNAME  )
);
--添加表用户应用桌面配置表的注释
COMMENT ON TABLE SYS_USERAPPDESKCFG IS '用户应用桌面配置表';
--添加表用户应用桌面配置表的列注释

COMMENT ON COLUMN SYS_USERAPPDESKCFG.PARTKEY IS '部件名称    ';

COMMENT ON COLUMN SYS_USERAPPDESKCFG.LOGINNAME IS '系统登录名    ,系统用户名 ';

COMMENT ON COLUMN SYS_USERAPPDESKCFG.TITLE IS '部件标题    ';

COMMENT ON COLUMN SYS_USERAPPDESKCFG.URL IS '部件Url    ';

COMMENT ON COLUMN SYS_USERAPPDESKCFG.MOREURL IS '更多Url    ';

COMMENT ON COLUMN SYS_USERAPPDESKCFG.COLUMNINDEX IS '列索引    ';

COMMENT ON COLUMN SYS_USERAPPDESKCFG.ROWINDEX IS '行索引    ';

COMMENT ON COLUMN SYS_USERAPPDESKCFG.REFID IS '引用Id    ';

COMMENT ON COLUMN SYS_USERAPPDESKCFG.ORGINDEX IS '原始索引    ';

COMMENT ON COLUMN SYS_USERAPPDESKCFG.CREATEDT IS '创建时间    ';

COMMENT ON COLUMN SYS_USERAPPDESKCFG.UPDATEDT IS '更新时间    ';
-- 外键索引

--删除表 数据传送单元
ALTER TABLE DEV_DTU
  DROP PRIMARY KEY CASCADE;
	DROP TABLE DEV_DTU CASCADE CONSTRAINTS;

--
-- 创建表 数据传送单元
--
CREATE TABLE DEV_DTU
(
	ID --- VARCHAR2(36) not null , --唯一Id(主键)	
	  SERVERID--- VARCHAR2(36)  null , --服务器Id
	  ZHUAN_BH--- NUMBER(10,0)  null , --充电站编号
	  DTUID--- VARCHAR2(32)  null , --设备ID
	  DTUTYPE--- VARCHAR2(64)  null , --设备型号
	  DTUNAME--- VARCHAR2(64)  null , --设备名称
	  PHONE--- VARCHAR2(16)  null , --SIM卡号
	  SVRPWD--- VARCHAR2(32)  null , --服务器登录密码
	  DTUSTATUS--- VARCHAR2(32)  null , --状态
	  CREATEDT--- DATE  null , --创建时间
	  UPDATEDT--- DATE  null , --更新时间 
	 constraint PK_DEV_DTU primary key (ID  )
);
--添加表数据传送单元的注释
COMMENT ON TABLE DEV_DTU IS '数据传送单元';
--添加表数据传送单元的列注释

COMMENT ON COLUMN DEV_DTU.ID IS '唯一Id    ';

COMMENT ON COLUMN DEV_DTU.SERVERID IS '服务器Id    ,唯一Id ';

COMMENT ON COLUMN DEV_DTU.ZHUAN_BH IS '充电站编号    ,3位数字 ';

COMMENT ON COLUMN DEV_DTU.DTUID IS '设备ID    ';

COMMENT ON COLUMN DEV_DTU.DTUTYPE IS '设备型号    ';

COMMENT ON COLUMN DEV_DTU.DTUNAME IS '设备名称    ';

COMMENT ON COLUMN DEV_DTU.PHONE IS 'SIM卡号    ';

COMMENT ON COLUMN DEV_DTU.SVRPWD IS '服务器登录密码    ';

COMMENT ON COLUMN DEV_DTU.DTUSTATUS IS '状态    ,未注册、已注册 ';

COMMENT ON COLUMN DEV_DTU.CREATEDT IS '创建时间    ';

COMMENT ON COLUMN DEV_DTU.UPDATEDT IS '更新时间    ';
-- 外键索引

--删除表 充电桩
ALTER TABLE DEV_CHARGPILE
  DROP PRIMARY KEY CASCADE;
	DROP TABLE DEV_CHARGPILE CASCADE CONSTRAINTS;

--
-- 创建表 充电桩
--
CREATE TABLE DEV_CHARGPILE
(
	DEV_CHARGPILE --- NUMBER(20,0) not null , --充电桩编号(主键)	
	  BOX_ID--- NUMBER(20,0)  null , --分支箱ID
	  DTU_ID--- VARCHAR2(36)  null , --传输单元ID
	  PILETYPEID--- VARCHAR2(16)  null , --充电桩类型Id
	  ZONGXIAN_DZ--- NUMBER(10,0)  null , --总线地址
	  ZHICHAN_BH--- VARCHAR2(64)  null , --资产号(编号)
	  YUNWEI_DW--- VARCHAR2(64)  null , --运维单位
	  DELETEFLAG--- DATE  null , --删除标记
	  CREATEDT--- DATE  null , --创建时间
	  UPDATEDT--- DATE  null , --更新时间 
	 constraint PK_DEV_CHARGPILE primary key (DEV_CHARGPILE  )
);
--添加表充电桩的注释
COMMENT ON TABLE DEV_CHARGPILE IS '充电桩';
--添加表充电桩的列注释

COMMENT ON COLUMN DEV_CHARGPILE.DEV_CHARGPILE IS '充电桩编号    ,3位充电站+2位分支箱+序号(3) ';

COMMENT ON COLUMN DEV_CHARGPILE.BOX_ID IS '分支箱ID    ,3位充电站+2位分支箱 ';

COMMENT ON COLUMN DEV_CHARGPILE.DTU_ID IS '传输单元ID    ,唯一Id ';

COMMENT ON COLUMN DEV_CHARGPILE.PILETYPEID IS '充电桩类型Id    ,按协议分的充电桩型号
6位字符
厂家：2位字母 NR(南瑞)  XJ(许继)  PT(普瑞特)
类型：2位字母 AC(交流)   DC(直流)
版本：2为数字
'-'连接 
如：NR-DC-01， XJ-AC-01 ';

COMMENT ON COLUMN DEV_CHARGPILE.ZONGXIAN_DZ IS '总线地址    ';

COMMENT ON COLUMN DEV_CHARGPILE.ZHICHAN_BH IS '资产号(编号)    ';

COMMENT ON COLUMN DEV_CHARGPILE.YUNWEI_DW IS '运维单位    ';

COMMENT ON COLUMN DEV_CHARGPILE.DELETEFLAG IS '删除标记    ';

COMMENT ON COLUMN DEV_CHARGPILE.CREATEDT IS '创建时间    ';

COMMENT ON COLUMN DEV_CHARGPILE.UPDATEDT IS '更新时间    ';
-- 外键索引

--删除表 分支箱
ALTER TABLE DEV_BRANCH
  DROP PRIMARY KEY CASCADE;
	DROP TABLE DEV_BRANCH CASCADE CONSTRAINTS;

--
-- 创建表 分支箱
--
CREATE TABLE DEV_BRANCH
(
	BRANCHNO --- NUMBER(20,0) not null , --分支箱编码(主键)	
	  ZHUAN_BH--- NUMBER(10,0)  null , --充电站编号
	  CHANQUAN_GX--- VARCHAR2(64)  null , --产权归属
	  YUNWEI_DW--- VARCHAR2(64)  null , --运维单位
	  CHANGJIA--- VARCHAR2(64)  null , --厂家
	  FENZHI_XLX--- VARCHAR2(64)  null , --分支箱类型
	  CREATEDT--- DATE  null , --创建时间
	  UPDATEDT--- DATE  null , --更新时间
	  ZHICHAN_BH--- VARCHAR2(64)  null , --资产号(编号) 
	 constraint PK_DEV_BRANCH primary key (BRANCHNO  )
);
--添加表分支箱的注释
COMMENT ON TABLE DEV_BRANCH IS '分支箱';
--添加表分支箱的列注释

COMMENT ON COLUMN DEV_BRANCH.BRANCHNO IS '分支箱编码    ,3位充电站+2位分支箱 ';

COMMENT ON COLUMN DEV_BRANCH.ZHUAN_BH IS '充电站编号    ,3位数字 ';

COMMENT ON COLUMN DEV_BRANCH.CHANQUAN_GX IS '产权归属    ';

COMMENT ON COLUMN DEV_BRANCH.YUNWEI_DW IS '运维单位    ';

COMMENT ON COLUMN DEV_BRANCH.CHANGJIA IS '厂家    ';

COMMENT ON COLUMN DEV_BRANCH.FENZHI_XLX IS '分支箱类型    ';

COMMENT ON COLUMN DEV_BRANCH.CREATEDT IS '创建时间    ';

COMMENT ON COLUMN DEV_BRANCH.UPDATEDT IS '更新时间    ';

COMMENT ON COLUMN DEV_BRANCH.ZHICHAN_BH IS '资产号(编号)    ';
-- 外键索引

--删除表 充电站
ALTER TABLE DEV_CHARGSTATION
  DROP PRIMARY KEY CASCADE;
	DROP TABLE DEV_CHARGSTATION CASCADE CONSTRAINTS;

--
-- 创建表 充电站
--
CREATE TABLE DEV_CHARGSTATION
(
	ZHAN_BH --- NUMBER(10,0) not null , --充电站编号(主键)	
	  ZHUAN_MC--- VARCHAR2(64)  null , --充电点名称
	  YEZHU_DW--- VARCHAR2(64)  null , --场地业主单位
	  LIANXI_R--- VARCHAR2(64)  null , --联系人
	  LIANXI_DH--- VARCHAR2(64)  null , --联系电话
	  ZHUANGLEI_X--- VARCHAR2(64)  null , --桩类型
	  ZHUANGCHANG_J--- VARCHAR2(64)  null , --桩厂家
	  XIANGXI_DZ--- VARCHAR2(64)  null , --详细地址
	  LONGTUDE--- DOUBLE PRECISION  null , --经度坐标
	  LATITUDE--- DOUBLE PRECISION  null , --维度坐标
	  CREATEDT--- DATE  null , --创建时间
	  UPDATEDT--- DATE  null , --更新时间 
	 constraint PK_DEV_CHARGSTATION primary key (ZHAN_BH  )
);
--添加表充电站的注释
COMMENT ON TABLE DEV_CHARGSTATION IS '充电站';
--添加表充电站的列注释

COMMENT ON COLUMN DEV_CHARGSTATION.ZHAN_BH IS '充电站编号    ,3位数字 ';

COMMENT ON COLUMN DEV_CHARGSTATION.ZHUAN_MC IS '充电点名称    ';

COMMENT ON COLUMN DEV_CHARGSTATION.YEZHU_DW IS '场地业主单位    ';

COMMENT ON COLUMN DEV_CHARGSTATION.LIANXI_R IS '联系人    ';

COMMENT ON COLUMN DEV_CHARGSTATION.LIANXI_DH IS '联系电话    ';

COMMENT ON COLUMN DEV_CHARGSTATION.ZHUANGLEI_X IS '桩类型    ';

COMMENT ON COLUMN DEV_CHARGSTATION.ZHUANGCHANG_J IS '桩厂家    ';

COMMENT ON COLUMN DEV_CHARGSTATION.XIANGXI_DZ IS '详细地址    ';

COMMENT ON COLUMN DEV_CHARGSTATION.LONGTUDE IS '经度坐标    ';

COMMENT ON COLUMN DEV_CHARGSTATION.LATITUDE IS '维度坐标    ';

COMMENT ON COLUMN DEV_CHARGSTATION.CREATEDT IS '创建时间    ';

COMMENT ON COLUMN DEV_CHARGSTATION.UPDATEDT IS '更新时间    ';
-- 外键索引

--删除表 数据中心服务器
ALTER TABLE DEV_SERVER
  DROP PRIMARY KEY CASCADE;
	DROP TABLE DEV_SERVER CASCADE CONSTRAINTS;

--
-- 创建表 数据中心服务器
--
CREATE TABLE DEV_SERVER
(
	ID --- VARCHAR2(36) not null , --唯一Id(主键)	
	  MINGCHENG--- VARCHAR2(64)  null , --数据中心名称
	  ZHU_IP--- VARCHAR2(64)  null , --主服务器IP
	  ZHU_YM--- VARCHAR2(64)  null , --主服务器域名
	  ZHU_DK--- NUMBER(10,0)  null , --主服务器端口
	  ZHU_LJMS--- VARCHAR2(32)  null , --主服务器连接模式
	  BEIYONG_IP--- VARCHAR2(64)  null , --备用服务器IP
	  BEIYONG_YM--- VARCHAR2(64)  null , --备用服务器域名
	  BEIYONG_DK--- NUMBER(10,0)  null , --备用服务器端口
	  BEIYONG_LJMS--- VARCHAR2(32)  null , --备用服务器连接模式
	  CREATEDT--- DATE  null , --创建时间
	  UPDATEDT--- DATE  null , --更新时间 
	 constraint PK_DEV_SERVER primary key (ID  )
);
--添加表数据中心服务器的注释
COMMENT ON TABLE DEV_SERVER IS '数据中心服务器';
--添加表数据中心服务器的列注释

COMMENT ON COLUMN DEV_SERVER.ID IS '唯一Id    ';

COMMENT ON COLUMN DEV_SERVER.MINGCHENG IS '数据中心名称    ';

COMMENT ON COLUMN DEV_SERVER.ZHU_IP IS '主服务器IP    ';

COMMENT ON COLUMN DEV_SERVER.ZHU_YM IS '主服务器域名    ';

COMMENT ON COLUMN DEV_SERVER.ZHU_DK IS '主服务器端口    ';

COMMENT ON COLUMN DEV_SERVER.ZHU_LJMS IS '主服务器连接模式    ';

COMMENT ON COLUMN DEV_SERVER.BEIYONG_IP IS '备用服务器IP    ';

COMMENT ON COLUMN DEV_SERVER.BEIYONG_YM IS '备用服务器域名    ';

COMMENT ON COLUMN DEV_SERVER.BEIYONG_DK IS '备用服务器端口    ';

COMMENT ON COLUMN DEV_SERVER.BEIYONG_LJMS IS '备用服务器连接模式    ';

COMMENT ON COLUMN DEV_SERVER.CREATEDT IS '创建时间    ';

COMMENT ON COLUMN DEV_SERVER.UPDATEDT IS '更新时间    ';
-- 外键索引

--删除表 充电桩全景图片
ALTER TABLE DEV_CHARGSTATIONFILE
  DROP PRIMARY KEY CASCADE;
	DROP TABLE DEV_CHARGSTATIONFILE CASCADE CONSTRAINTS;

--
-- 创建表 充电桩全景图片
--
CREATE TABLE DEV_CHARGSTATIONFILE
(
	  ZHAN_BH--- NUMBER(10,0)  null , --充电站编号
	  ID--- VARCHAR2(36)  null , --唯一Id
	  FILENAME--- VARCHAR2(64)  null , --文件名称
	  FILECONTEXT--- LONG RAW  null , --文件内容
	  FILESIZE--- NUMBER(10,0)  null , --文件大小
	  FILEMIME--- VARCHAR2(64)  null , --文件MIME
	  CREATEDT--- DATE  null , --创建时间
	  UPDATEDT--- DATE  null , --更新时间 
	 constraint PK_DEV_CHARGSTATIONFILE primary key ()
);
--添加表充电桩全景图片的注释
COMMENT ON TABLE DEV_CHARGSTATIONFILE IS '充电桩全景图片';
--添加表充电桩全景图片的列注释

COMMENT ON COLUMN DEV_CHARGSTATIONFILE.ZHAN_BH IS '充电站编号    ,3位数字 ';

COMMENT ON COLUMN DEV_CHARGSTATIONFILE.ID IS '唯一Id    ';

COMMENT ON COLUMN DEV_CHARGSTATIONFILE.FILENAME IS '文件名称    ';

COMMENT ON COLUMN DEV_CHARGSTATIONFILE.FILECONTEXT IS '文件内容    ';

COMMENT ON COLUMN DEV_CHARGSTATIONFILE.FILESIZE IS '文件大小    ';

COMMENT ON COLUMN DEV_CHARGSTATIONFILE.FILEMIME IS '文件MIME    ';

COMMENT ON COLUMN DEV_CHARGSTATIONFILE.CREATEDT IS '创建时间    ';

COMMENT ON COLUMN DEV_CHARGSTATIONFILE.UPDATEDT IS '更新时间    ';
-- 外键索引

--删除表 充电桩型号码表
ALTER TABLE DEV_POWERPILETYPES
  DROP PRIMARY KEY CASCADE;
	DROP TABLE DEV_POWERPILETYPES CASCADE CONSTRAINTS;

--
-- 创建表 充电桩型号码表
--
CREATE TABLE DEV_POWERPILETYPES
(
	PARSERKEY --- VARCHAR2(16) not null , --协议标识编码(主键)	
	  CHANGJIA--- VARCHAR2(64)  null , --厂家
	  ZHUANGLEI_X--- VARCHAR2(64)  null , --桩类型
	  DTUTYPE--- VARCHAR2(64)  null , --设备型号
	  REMARK--- VARCHAR2(256)  null , --备注
	  PARSERASSEMBLY--- VARCHAR2(256)  null , --协议解析器程序集
	  PARSERTYPE--- VARCHAR2(256)  null , --协议解析器类型
	  CREATEDT--- DATE  null , --创建时间
	  UPDATEDT--- DATE  null , --更新时间 
	 constraint PK_DEV_POWERPILETYPES primary key (PARSERKEY  )
);
--添加表充电桩型号码表的注释
COMMENT ON TABLE DEV_POWERPILETYPES IS '充电桩型号码表';
--添加表充电桩型号码表的列注释

COMMENT ON COLUMN DEV_POWERPILETYPES.PARSERKEY IS '协议标识编码    ,按协议分的充电桩型号
6位字符
厂家：2位字母 NR(南瑞)  XJ(许继)  PT(普瑞特)
类型：2位字母 AC(交流)   DC(直流)
版本：2为数字
'-'连接 
如：NR-DC-01， XJ-AC-01 ';

COMMENT ON COLUMN DEV_POWERPILETYPES.CHANGJIA IS '厂家    ';

COMMENT ON COLUMN DEV_POWERPILETYPES.ZHUANGLEI_X IS '桩类型    ';

COMMENT ON COLUMN DEV_POWERPILETYPES.DTUTYPE IS '设备型号    ';

COMMENT ON COLUMN DEV_POWERPILETYPES.REMARK IS '备注    ';

COMMENT ON COLUMN DEV_POWERPILETYPES.PARSERASSEMBLY IS '协议解析器程序集    ';

COMMENT ON COLUMN DEV_POWERPILETYPES.PARSERTYPE IS '协议解析器类型    ';

COMMENT ON COLUMN DEV_POWERPILETYPES.CREATEDT IS '创建时间    ';

COMMENT ON COLUMN DEV_POWERPILETYPES.UPDATEDT IS '更新时间    ';
-- 外键索引

--删除表 遥测数据
ALTER TABLE GAT_DATA_YC
  DROP PRIMARY KEY CASCADE;
	DROP TABLE GAT_DATA_YC CASCADE CONSTRAINTS;

--
-- 创建表 遥测数据
--
CREATE TABLE GAT_DATA_YC
(
	ID --- VARCHAR2(36) not null , --唯一Id(主键)	
	  ZHUAN_ID--- NUMBER(20,0)  null , --充电桩ID
	  GATITEMID--- VARCHAR2(64)  null , --采集项标识
	  GATDT--- DATE  null , --采集时间
	  CYCLETYPE--- VARCHAR2(32)  null , --周期类型
	  M_VALUE--- NUMERIC(22,2)  null , --值(浮点形式)
	  M_VALUESTRING--- VARCHAR2(64)  null , --值(字符串形式)
	  QUALITY--- VARCHAR2(64)  null , --数据质量
	  CREATEDT--- DATE  null , --创建时间
	  UPDATEDT--- DATE  null , --更新时间 
	 constraint PK_GAT_DATA_YC primary key (ID  )
);
--添加表遥测数据的注释
COMMENT ON TABLE GAT_DATA_YC IS '遥测数据';
--添加表遥测数据的列注释

COMMENT ON COLUMN GAT_DATA_YC.ID IS '唯一Id    ';

COMMENT ON COLUMN GAT_DATA_YC.ZHUAN_ID IS '充电桩ID    ,3位充电站+2位分支箱+序号(3) ';

COMMENT ON COLUMN GAT_DATA_YC.GATITEMID IS '采集项标识    ';

COMMENT ON COLUMN GAT_DATA_YC.GATDT IS '采集时间    ';

COMMENT ON COLUMN GAT_DATA_YC.CYCLETYPE IS '周期类型    ';

COMMENT ON COLUMN GAT_DATA_YC.M_VALUE IS '值(浮点形式)    ';

COMMENT ON COLUMN GAT_DATA_YC.M_VALUESTRING IS '值(字符串形式)    ,原始报文的Base64字符串 ';

COMMENT ON COLUMN GAT_DATA_YC.QUALITY IS '数据质量    ';

COMMENT ON COLUMN GAT_DATA_YC.CREATEDT IS '创建时间    ';

COMMENT ON COLUMN GAT_DATA_YC.UPDATEDT IS '更新时间    ';
-- 外键索引

--删除表 遥信数据
ALTER TABLE GAT_DATA_YX
  DROP PRIMARY KEY CASCADE;
	DROP TABLE GAT_DATA_YX CASCADE CONSTRAINTS;

--
-- 创建表 遥信数据
--
CREATE TABLE GAT_DATA_YX
(
	ID --- VARCHAR2(36) not null , --唯一Id(主键)	
	  ZHUAN_ID--- NUMBER(20,0)  null , --充电桩ID
	  GATITEMID--- VARCHAR2(64)  null , --采集项标识
	  GATDT--- DATE  null , --采集时间
	  CYCLETYPE--- VARCHAR2(32)  null , --周期类型
	  M_VALUE--- NUMERIC(22,2)  null , --值(浮点形式)
	  M_VALUESTRING--- VARCHAR2(64)  null , --值(字符串形式)
	  QUALITY--- VARCHAR2(64)  null , --数据质量
	  CREATEDT--- DATE  null , --创建时间
	  UPDATEDT--- DATE  null , --更新时间 
	 constraint PK_GAT_DATA_YX primary key (ID  )
);
--添加表遥信数据的注释
COMMENT ON TABLE GAT_DATA_YX IS '遥信数据';
--添加表遥信数据的列注释

COMMENT ON COLUMN GAT_DATA_YX.ID IS '唯一Id    ';

COMMENT ON COLUMN GAT_DATA_YX.ZHUAN_ID IS '充电桩ID    ,3位充电站+2位分支箱+序号(3) ';

COMMENT ON COLUMN GAT_DATA_YX.GATITEMID IS '采集项标识    ';

COMMENT ON COLUMN GAT_DATA_YX.GATDT IS '采集时间    ';

COMMENT ON COLUMN GAT_DATA_YX.CYCLETYPE IS '周期类型    ';

COMMENT ON COLUMN GAT_DATA_YX.M_VALUE IS '值(浮点形式)    ';

COMMENT ON COLUMN GAT_DATA_YX.M_VALUESTRING IS '值(字符串形式)    ,原始报文的Base64字符串 ';

COMMENT ON COLUMN GAT_DATA_YX.QUALITY IS '数据质量    ';

COMMENT ON COLUMN GAT_DATA_YX.CREATEDT IS '创建时间    ';

COMMENT ON COLUMN GAT_DATA_YX.UPDATEDT IS '更新时间    ';
-- 外键索引

--删除表 数据项
ALTER TABLE GAT_ITEM
  DROP PRIMARY KEY CASCADE;
	DROP TABLE GAT_ITEM CASCADE CONSTRAINTS;

--
-- 创建表 数据项
--
CREATE TABLE GAT_ITEM
(
	ITEMNO --- VARCHAR2(64) not null , --采集项标识(主键)	
	  ITEMNAME--- VARCHAR2(64)  null , --采集项名称
	  ITEMDESC--- VARCHAR2(256)  null , --采集项描述
	  REFCONTEXT--- VARCHAR2(64)  null , --关联主体
	  M_UNITS--- VARCHAR2(64)  null , --计量单位
	  DATATYPE--- VARCHAR2(32)  null , --数据类型
	  VALUETYPE--- VARCHAR2(32)  null , --测量值类型
	  CREATEDT--- DATE  null , --创建时间
	  UPDATEDT--- DATE  null , --更新时间 
	 constraint PK_GAT_ITEM primary key (ITEMNO  )
);
--添加表数据项的注释
COMMENT ON TABLE GAT_ITEM IS '数据项';
--添加表数据项的列注释

COMMENT ON COLUMN GAT_ITEM.ITEMNO IS '采集项标识    ';

COMMENT ON COLUMN GAT_ITEM.ITEMNAME IS '采集项名称    ';

COMMENT ON COLUMN GAT_ITEM.ITEMDESC IS '采集项描述    ';

COMMENT ON COLUMN GAT_ITEM.REFCONTEXT IS '关联主体    ,充电桩、车、电池、充值卡 ';

COMMENT ON COLUMN GAT_ITEM.M_UNITS IS '计量单位    ';

COMMENT ON COLUMN GAT_ITEM.DATATYPE IS '数据类型    ,YC：遥测
YK：遥控
YT：遥调
YX：遥信 ';

COMMENT ON COLUMN GAT_ITEM.VALUETYPE IS '测量值类型    ,String：字符串类型	
Numeric：字符串类型 ';

COMMENT ON COLUMN GAT_ITEM.CREATEDT IS '创建时间    ';

COMMENT ON COLUMN GAT_ITEM.UPDATEDT IS '更新时间    ';
-- 外键索引

--删除表 告警方式
ALTER TABLE GAT_WARN
  DROP PRIMARY KEY CASCADE;
	DROP TABLE GAT_WARN CASCADE CONSTRAINTS;

--
-- 创建表 告警方式
--
CREATE TABLE GAT_WARN
(
	ID --- VARCHAR2(36) not null , --唯一Id(主键)	
	  WARNTYPE--- VARCHAR2(32)  null , --告警方式
	  WARNTARGET--- VARCHAR2(1000)  null , --告警目标
	  WARNCONTEXT--- VARCHAR2(1000)  null , --告警内容模板
	  CREATEDT--- DATE  null , --创建时间
	  UPDATEDT--- DATE  null , --更新时间 
	 constraint PK_GAT_WARN primary key (ID  )
);
--添加表告警方式的注释
COMMENT ON TABLE GAT_WARN IS '告警方式';
--添加表告警方式的列注释

COMMENT ON COLUMN GAT_WARN.ID IS '唯一Id    ';

COMMENT ON COLUMN GAT_WARN.WARNTYPE IS '告警方式    ';

COMMENT ON COLUMN GAT_WARN.WARNTARGET IS '告警目标    ,邮件方式：邮件地址多个用分号隔开
短信方式：手机号码,分号隔开 ';

COMMENT ON COLUMN GAT_WARN.WARNCONTEXT IS '告警内容模板    ';

COMMENT ON COLUMN GAT_WARN.CREATEDT IS '创建时间    ';

COMMENT ON COLUMN GAT_WARN.UPDATEDT IS '更新时间    ';
-- 外键索引

--删除表 测量点配置表
ALTER TABLE GAT_POINTCFG
  DROP PRIMARY KEY CASCADE;
	DROP TABLE GAT_POINTCFG CASCADE CONSTRAINTS;

--
-- 创建表 测量点配置表
--
CREATE TABLE GAT_POINTCFG
(
	ID --- VARCHAR2(36) not null , --唯一Id(主键)	
	  GATITEMID--- VARCHAR2(64)  null , --采集项标识
	  WARNID--- VARCHAR2(36)  null , --告警方式Id
	  PILETYPEID--- VARCHAR2(16)  null , --充电桩型号Id
	  ISUSE--- NUMBER(1,0)  null , --是否启用
	  CYCLETYPE--- VARCHAR2(32)  null , --周期类型
	  LIMITMIN--- NUMERIC(22,2)  null , --阈值最小值
	  LIMITMAX--- NUMERIC(22,2)  null , --阈值最大值
	  ISOVERLIMTWARN--- NUMBER(1,0)  null , --超阈值告警
	  EFF_MIN--- NUMERIC(22,2)  null , --有效值最小值
	  EFF_MAX--- NUMERIC(22,2)  null , --有效值最大值
	  ISOVEREFFWARN--- NUMBER(1,0)  null , --超有效值告警
	  CREATEDT--- DATE  null , --创建时间
	  UPDATEDT--- DATE  null , --更新时间 
	 constraint PK_GAT_POINTCFG primary key (ID  )
);
--添加表测量点配置表的注释
COMMENT ON TABLE GAT_POINTCFG IS '测量点配置表';
--添加表测量点配置表的列注释

COMMENT ON COLUMN GAT_POINTCFG.ID IS '唯一Id    ';

COMMENT ON COLUMN GAT_POINTCFG.GATITEMID IS '采集项标识    ';

COMMENT ON COLUMN GAT_POINTCFG.WARNID IS '告警方式Id    ,唯一Id ';

COMMENT ON COLUMN GAT_POINTCFG.PILETYPEID IS '充电桩型号Id    ,按协议分的充电桩型号
6位字符
厂家：2位字母 NR(南瑞)  XJ(许继)  PT(普瑞特)
类型：2位字母 AC(交流)   DC(直流)
版本：2为数字
'-'连接 
如：NR-DC-01， XJ-AC-01 ';

COMMENT ON COLUMN GAT_POINTCFG.ISUSE IS '是否启用    ';

COMMENT ON COLUMN GAT_POINTCFG.CYCLETYPE IS '周期类型    ';

COMMENT ON COLUMN GAT_POINTCFG.LIMITMIN IS '阈值最小值    ';

COMMENT ON COLUMN GAT_POINTCFG.LIMITMAX IS '阈值最大值    ';

COMMENT ON COLUMN GAT_POINTCFG.ISOVERLIMTWARN IS '超阈值告警    ';

COMMENT ON COLUMN GAT_POINTCFG.EFF_MIN IS '有效值最小值    ';

COMMENT ON COLUMN GAT_POINTCFG.EFF_MAX IS '有效值最大值    ';

COMMENT ON COLUMN GAT_POINTCFG.ISOVEREFFWARN IS '超有效值告警    ';

COMMENT ON COLUMN GAT_POINTCFG.CREATEDT IS '创建时间    ';

COMMENT ON COLUMN GAT_POINTCFG.UPDATEDT IS '更新时间    ';
-- 外键索引

--删除表 充电记录
ALTER TABLE GAT_DATA_RECORD
  DROP PRIMARY KEY CASCADE;
	DROP TABLE GAT_DATA_RECORD CASCADE CONSTRAINTS;

--
-- 创建表 充电记录
--
CREATE TABLE GAT_DATA_RECORD
(
	ID --- VARCHAR2(36) not null , --唯一Id(主键)	
	  ZHUAN_ID--- NUMBER(20,0)  null , --充电桩ID
	  TERMINAL_NO--- NUMBER(20,0)  null , --终端编号
	  CHECKOUT_NO--- NUMBER(20,0)  null , --结算凭条编号
	  CREDITCARDDT--- DATE  null , --刷卡结算时间
	  STARTDT--- DATE  null , --启动充电时间
	  ENDDT--- DATE  null , --结束充电时间
	  CARD_NO--- VARCHAR2(16)  null , --卡号
	  CARD_START_MONEY--- NUMBER(20,0)  null , --卡起始余额
	  CARD_END_MONEY--- NUMBER(20,0)  null , --卡剩余金额
	  POWER_HIGH--- NUMBER(20,0)  null , --峰时段充电电量
	  MONEY_HIGH--- NUMBER(20,0)  null , --峰时段充电金额
	  VALUE_HIGH--- NUMBER(20,0)  null , --峰时段电价
	  POWER_LOW--- NUMBER(20,0)  null , --谷时段充电电量
	  MONEY_LOW--- NUMBER(20,0)  null , --谷时段充电金额
	  VALUE_LOW--- NUMBER(20,0)  null , --谷时段电价
	  POWER_TIP--- NUMBER(20,0)  null , --尖时段充电电量
	  MONEY_TIP--- NUMBER(20,0)  null , --尖时段充电金额
	  VALUE_TIP--- NUMBER(20,0)  null , --尖时段电价
	  POWER_NORMAL--- NUMBER(20,0)  null , --平时段充电电量
	  MONEY_NORMAL--- NUMBER(20,0)  null , --平时段充电金额
	  VALUE_NORMAL--- NUMBER(20,0)  null , --平时段电价
	  CHARGE_POWER--- NUMBER(20,0)  null , --充电总电量
	  CHARGE_MONEY--- NUMBER(20,0)  null , --充电总金额
	  CHARGE_TIME_HOUR--- NUMBER(3,0)  null , --充电的分钟数
	  CHARGE_TIME_MIN--- NUMBER(3,0)  null , --充电小时数
	  STOP_TYPE--- NUMBER(10,0)  null , --停止充电原因
	  CREATEDT--- DATE  null , --创建时间
	  UPDATEDT--- DATE  null , --更新时间 
	 constraint PK_GAT_DATA_RECORD primary key (ID  )
);
--添加表充电记录的注释
COMMENT ON TABLE GAT_DATA_RECORD IS '充电记录';
--添加表充电记录的列注释

COMMENT ON COLUMN GAT_DATA_RECORD.ID IS '唯一Id    ';

COMMENT ON COLUMN GAT_DATA_RECORD.ZHUAN_ID IS '充电桩ID    ,3位充电站+2位分支箱+序号(3) ';

COMMENT ON COLUMN GAT_DATA_RECORD.TERMINAL_NO IS '终端编号    ';

COMMENT ON COLUMN GAT_DATA_RECORD.CHECKOUT_NO IS '结算凭条编号    ';

COMMENT ON COLUMN GAT_DATA_RECORD.CREDITCARDDT IS '刷卡结算时间    ';

COMMENT ON COLUMN GAT_DATA_RECORD.STARTDT IS '启动充电时间    ';

COMMENT ON COLUMN GAT_DATA_RECORD.ENDDT IS '结束充电时间    ';

COMMENT ON COLUMN GAT_DATA_RECORD.CARD_NO IS '卡号    ,BDC格式，每字节存一位卡号，第一个字节存最高位，最后一个字节存最低位 ';

COMMENT ON COLUMN GAT_DATA_RECORD.CARD_START_MONEY IS '卡起始余额    ';

COMMENT ON COLUMN GAT_DATA_RECORD.CARD_END_MONEY IS '卡剩余金额    ';

COMMENT ON COLUMN GAT_DATA_RECORD.POWER_HIGH IS '峰时段充电电量    ';

COMMENT ON COLUMN GAT_DATA_RECORD.MONEY_HIGH IS '峰时段充电金额    ';

COMMENT ON COLUMN GAT_DATA_RECORD.VALUE_HIGH IS '峰时段电价    ';

COMMENT ON COLUMN GAT_DATA_RECORD.POWER_LOW IS '谷时段充电电量    ';

COMMENT ON COLUMN GAT_DATA_RECORD.MONEY_LOW IS '谷时段充电金额    ';

COMMENT ON COLUMN GAT_DATA_RECORD.VALUE_LOW IS '谷时段电价    ';

COMMENT ON COLUMN GAT_DATA_RECORD.POWER_TIP IS '尖时段充电电量    ';

COMMENT ON COLUMN GAT_DATA_RECORD.MONEY_TIP IS '尖时段充电金额    ';

COMMENT ON COLUMN GAT_DATA_RECORD.VALUE_TIP IS '尖时段电价    ';

COMMENT ON COLUMN GAT_DATA_RECORD.POWER_NORMAL IS '平时段充电电量    ';

COMMENT ON COLUMN GAT_DATA_RECORD.MONEY_NORMAL IS '平时段充电金额    ';

COMMENT ON COLUMN GAT_DATA_RECORD.VALUE_NORMAL IS '平时段电价    ';

COMMENT ON COLUMN GAT_DATA_RECORD.CHARGE_POWER IS '充电总电量    ';

COMMENT ON COLUMN GAT_DATA_RECORD.CHARGE_MONEY IS '充电总金额    ';

COMMENT ON COLUMN GAT_DATA_RECORD.CHARGE_TIME_HOUR IS '充电的分钟数    ';

COMMENT ON COLUMN GAT_DATA_RECORD.CHARGE_TIME_MIN IS '充电小时数    ';

COMMENT ON COLUMN GAT_DATA_RECORD.STOP_TYPE IS '停止充电原因    ,停止充电的原因定义如下：
1  //余额不足
2  //充够金额
3  //充够电量
4  //充够时间
5  //汽车自动停止
6  //刷卡结算
7  //充电输出失败
8  //故障中断
9  //未结算 ';

COMMENT ON COLUMN GAT_DATA_RECORD.CREATEDT IS '创建时间    ';

COMMENT ON COLUMN GAT_DATA_RECORD.UPDATEDT IS '更新时间    ';
-- 外键索引

--删除表 告警处理明细表
ALTER TABLE GAT_WARNDETAIL
  DROP PRIMARY KEY CASCADE;
	DROP TABLE GAT_WARNDETAIL CASCADE CONSTRAINTS;

--
-- 创建表 告警处理明细表
--
CREATE TABLE GAT_WARNDETAIL
(
	ID --- VARCHAR2(36) not null , --唯一Id(主键)	
	  WARNID--- VARCHAR2(36)  null , --告警方式Id
	  GATHERID--- VARCHAR2(36)  null , --采集数据Id
	  ADDRESS--- VARCHAR2(32)  null , --目标地址
	  ISSUCCESS--- NUMBER(1,0)  null , --发送成功
	  SENDDT--- DATE  null , --发送时间
	  WARNCONTEXT--- VARCHAR2(1000)  null , --告警内容
	  WARNTYPE--- VARCHAR2(32)  null , --告警方式
	  PROCESSFLAG--- NUMBER(1,0)  null , --处理标志
	  UPDATEDT--- DATE  null , --更新时间
	  CREATEDT--- DATE  null , --创建时间 
	 constraint PK_GAT_WARNDETAIL primary key (ID  )
);
--添加表告警处理明细表的注释
COMMENT ON TABLE GAT_WARNDETAIL IS '告警处理明细表';
--添加表告警处理明细表的列注释

COMMENT ON COLUMN GAT_WARNDETAIL.ID IS '唯一Id    ';

COMMENT ON COLUMN GAT_WARNDETAIL.WARNID IS '告警方式Id    ,唯一Id ';

COMMENT ON COLUMN GAT_WARNDETAIL.GATHERID IS '采集数据Id    ,唯一Id ';

COMMENT ON COLUMN GAT_WARNDETAIL.ADDRESS IS '目标地址    ';

COMMENT ON COLUMN GAT_WARNDETAIL.ISSUCCESS IS '发送成功    ';

COMMENT ON COLUMN GAT_WARNDETAIL.SENDDT IS '发送时间    ';

COMMENT ON COLUMN GAT_WARNDETAIL.WARNCONTEXT IS '告警内容    ';

COMMENT ON COLUMN GAT_WARNDETAIL.WARNTYPE IS '告警方式    ';

COMMENT ON COLUMN GAT_WARNDETAIL.PROCESSFLAG IS '处理标志    ,0：未处理 1：已处理 ';

COMMENT ON COLUMN GAT_WARNDETAIL.UPDATEDT IS '更新时间    ';

COMMENT ON COLUMN GAT_WARNDETAIL.CREATEDT IS '创建时间    ';
-- 外键索引

--删除表 充电价格维护
ALTER TABLE CFG_CHARGPRICE
  DROP PRIMARY KEY CASCADE;
	DROP TABLE CFG_CHARGPRICE CASCADE CONSTRAINTS;

--
-- 创建表 充电价格维护
--
CREATE TABLE CFG_CHARGPRICE
(
	ID --- VARCHAR2(36) not null , --唯一Id(主键)	
	  NAME--- VARCHAR2(64)  null , --名称
	  BEGINDT--- DATE  null , --开始时间
	  ENDDT--- DATE  null , --结束时间
	  PRICE--- NUMBER(19,1)  null , --价格
	  CREATEDT--- DATE  null , --创建时间
	  UPDATEDT--- DATE  null , --更新时间 
	 constraint PK_CFG_CHARGPRICE primary key (ID  )
);
--添加表充电价格维护的注释
COMMENT ON TABLE CFG_CHARGPRICE IS '充电价格维护';
--添加表充电价格维护的列注释

COMMENT ON COLUMN CFG_CHARGPRICE.ID IS '唯一Id    ';

COMMENT ON COLUMN CFG_CHARGPRICE.NAME IS '名称    ';

COMMENT ON COLUMN CFG_CHARGPRICE.BEGINDT IS '开始时间    ';

COMMENT ON COLUMN CFG_CHARGPRICE.ENDDT IS '结束时间    ';

COMMENT ON COLUMN CFG_CHARGPRICE.PRICE IS '价格    ';

COMMENT ON COLUMN CFG_CHARGPRICE.CREATEDT IS '创建时间    ';

COMMENT ON COLUMN CFG_CHARGPRICE.UPDATEDT IS '更新时间    ';
-- 外键索引

--删除表 操作日志
ALTER TABLE OTH_OPRLOG
  DROP PRIMARY KEY CASCADE;
	DROP TABLE OTH_OPRLOG CASCADE CONSTRAINTS;

--
-- 创建表 操作日志
--
CREATE TABLE OTH_OPRLOG
(
	ID --- VARCHAR2(36) not null , --唯一Id(主键)	
	  DATAITEMID--- VARCHAR2(64)  null , --数据项编码
	  TARGETDEV--- NUMBER(20,0)  null , --目标设备
	  OPERATOR--- VARCHAR2(64)  null , --操作员
	  LOGDATE--- DATE  null , --记录时间
	  OPERRESULT--- VARCHAR2(64)  null , --操作结果
	  CREATEDT--- DATE  null , --创建时间
	  UPDATEDT--- DATE  null , --更新时间
	  OPRSRC--- VARCHAR2(64)  null , --操作来源
	  OPRDEST--- VARCHAR2(64)  null , --操作目标 
	 constraint PK_OTH_OPRLOG primary key (ID  )
);
--添加表操作日志的注释
COMMENT ON TABLE OTH_OPRLOG IS '操作日志';
--添加表操作日志的列注释

COMMENT ON COLUMN OTH_OPRLOG.ID IS '唯一Id    ';

COMMENT ON COLUMN OTH_OPRLOG.DATAITEMID IS '数据项编码    ,采集项标识 ';

COMMENT ON COLUMN OTH_OPRLOG.TARGETDEV IS '目标设备    ,3位充电站+2位分支箱+序号(3) ';

COMMENT ON COLUMN OTH_OPRLOG.OPERATOR IS '操作员    ';

COMMENT ON COLUMN OTH_OPRLOG.LOGDATE IS '记录时间    ';

COMMENT ON COLUMN OTH_OPRLOG.OPERRESULT IS '操作结果    ';

COMMENT ON COLUMN OTH_OPRLOG.CREATEDT IS '创建时间    ';

COMMENT ON COLUMN OTH_OPRLOG.UPDATEDT IS '更新时间    ';

COMMENT ON COLUMN OTH_OPRLOG.OPRSRC IS '操作来源    ';

COMMENT ON COLUMN OTH_OPRLOG.OPRDEST IS '操作目标    ';
-- 外键索引

--删除表 SCADA告警记录
ALTER TABLE OTH_WARNREC
  DROP PRIMARY KEY CASCADE;
	DROP TABLE OTH_WARNREC CASCADE CONSTRAINTS;

--
-- 创建表 SCADA告警记录
--
CREATE TABLE OTH_WARNREC
(
	ID --- VARCHAR2(36) not null , --唯一Id(主键)	
	  DATAITEMID--- VARCHAR2(64)  null , --数据项编码
	  TARGETDEV--- NUMBER(20,0)  null , --目标设备
	  DATAGATHERID--- VARCHAR2(36)  null , --数据采集Id
	  OCCURDT--- DATE  null , --发生时间
	  LOGTYPE--- VARCHAR2(64)  null , --异常类型
	  M_VALUE--- NUMERIC(22,2)  null , --值(浮点形式)
	  LOGDESC--- VARCHAR2(256)  null , --异常说明
	  CREATEDT--- DATE  null , --创建时间
	  UPDATEDT--- DATE  null , --更新时间
	  PROCESSFLAG--- NUMBER(1,0)  null , --告警处理标志 
	 constraint PK_OTH_WARNREC primary key (ID  )
);
--添加表SCADA告警记录的注释
COMMENT ON TABLE OTH_WARNREC IS 'SCADA告警记录';
--添加表SCADA告警记录的列注释

COMMENT ON COLUMN OTH_WARNREC.ID IS '唯一Id    ';

COMMENT ON COLUMN OTH_WARNREC.DATAITEMID IS '数据项编码    ,采集项标识 ';

COMMENT ON COLUMN OTH_WARNREC.TARGETDEV IS '目标设备    ,3位充电站+2位分支箱+序号(3) ';

COMMENT ON COLUMN OTH_WARNREC.DATAGATHERID IS '数据采集Id    ,唯一Id ';

COMMENT ON COLUMN OTH_WARNREC.OCCURDT IS '发生时间    ';

COMMENT ON COLUMN OTH_WARNREC.LOGTYPE IS '异常类型    ';

COMMENT ON COLUMN OTH_WARNREC.M_VALUE IS '值(浮点形式)    ';

COMMENT ON COLUMN OTH_WARNREC.LOGDESC IS '异常说明    ';

COMMENT ON COLUMN OTH_WARNREC.CREATEDT IS '创建时间    ';

COMMENT ON COLUMN OTH_WARNREC.UPDATEDT IS '更新时间    ';

COMMENT ON COLUMN OTH_WARNREC.PROCESSFLAG IS '告警处理标志    ,已处理、未处理 ';
-- 外键索引

--删除表 网络状态表
ALTER TABLE OTH_NETSTATES
  DROP PRIMARY KEY CASCADE;
	DROP TABLE OTH_NETSTATES CASCADE CONSTRAINTS;

--
-- 创建表 网络状态表
--
CREATE TABLE OTH_NETSTATES
(
	  DTUID--- VARCHAR2(36)  null , --数据传输单元ID
	  ID--- VARCHAR2(36)  null , --唯一Id
	  NETSTATE--- VARCHAR2(32)  null , --网络状态
	  REMARK--- VARCHAR2(256)  null , --备注
	  CREATEDT--- DATE  null , --创建时间
	  UPDATEDT--- DATE  null , --更新时间 
	 constraint PK_OTH_NETSTATES primary key ()
);
--添加表网络状态表的注释
COMMENT ON TABLE OTH_NETSTATES IS '网络状态表';
--添加表网络状态表的列注释

COMMENT ON COLUMN OTH_NETSTATES.DTUID IS '数据传输单元ID    ,唯一Id ';

COMMENT ON COLUMN OTH_NETSTATES.ID IS '唯一Id    ';

COMMENT ON COLUMN OTH_NETSTATES.NETSTATE IS '网络状态    ,000：正常已连接
001：断线
002：未连接
999：未知异常 ';

COMMENT ON COLUMN OTH_NETSTATES.REMARK IS '备注    ';

COMMENT ON COLUMN OTH_NETSTATES.CREATEDT IS '创建时间    ';

COMMENT ON COLUMN OTH_NETSTATES.UPDATEDT IS '更新时间    ';
-- 外键索引

--删除表 充电桩实时状态
ALTER TABLE OTH_PILESTATES
  DROP PRIMARY KEY CASCADE;
	DROP TABLE OTH_PILESTATES CASCADE CONSTRAINTS;

--
-- 创建表 充电桩实时状态
--
CREATE TABLE OTH_PILESTATES
(
	POWERPILENO --- NUMBER(20,0) not null , --充电站编号(主键)	
	  POWERPILESTATUS--- NUMBER(3,0)  null , --充电桩状态
	  CREATEDT--- DATE  null , --创建时间
	  UPDATEDT--- DATE  null , --更新时间 
	 constraint PK_OTH_PILESTATES primary key (POWERPILENO  )
);
--添加表充电桩实时状态的注释
COMMENT ON TABLE OTH_PILESTATES IS '充电桩实时状态';
--添加表充电桩实时状态的列注释

COMMENT ON COLUMN OTH_PILESTATES.POWERPILENO IS '充电站编号    ,3位充电站+2位分支箱+序号(3) ';

COMMENT ON COLUMN OTH_PILESTATES.POWERPILESTATUS IS '充电桩状态    ,待机  1
充电  2
充满  3
离线  4
异常  5 ';

COMMENT ON COLUMN OTH_PILESTATES.CREATEDT IS '创建时间    ';

COMMENT ON COLUMN OTH_PILESTATES.UPDATEDT IS '更新时间    ';
-- 外键索引

--删除表 控制命令队列表
ALTER TABLE CMD_REQUEST
  DROP PRIMARY KEY CASCADE;
	DROP TABLE CMD_REQUEST CASCADE CONSTRAINTS;

--
-- 创建表 控制命令队列表
--
CREATE TABLE CMD_REQUEST
(
	ID --- VARCHAR2(36) not null , --唯一Id(主键)	
	  DTUID--- VARCHAR2(36)  null , --传送目标
	  REQDATA--- VARCHAR2(1000)  null , --命令请求数据
	  EXCUTEDT--- DATE  null , --命令执行时间
	  EXCUTESTATE--- VARCHAR2(32)  null , --执行状态
	  ISSUCCESS--- NUMBER(1,0)  null , --是否成功
	  DESTADDR--- NUMBER(10,0)  null , --充电桩地址
	  REMARK--- VARCHAR2(256)  null , --备注
	  CREATEDT--- DATE  null , --创建时间
	  UPDATEDT--- DATE  null , --更新时间 
	 constraint PK_CMD_REQUEST primary key (ID  )
);
--添加表控制命令队列表的注释
COMMENT ON TABLE CMD_REQUEST IS '控制命令队列表';
--添加表控制命令队列表的列注释

COMMENT ON COLUMN CMD_REQUEST.ID IS '唯一Id    ';

COMMENT ON COLUMN CMD_REQUEST.DTUID IS '传送目标    ,唯一Id ';

COMMENT ON COLUMN CMD_REQUEST.REQDATA IS '命令请求数据    ,CAN命令的BASE64形式 ';

COMMENT ON COLUMN CMD_REQUEST.EXCUTEDT IS '命令执行时间    ';

COMMENT ON COLUMN CMD_REQUEST.EXCUTESTATE IS '执行状态    ';

COMMENT ON COLUMN CMD_REQUEST.ISSUCCESS IS '是否成功    ';

COMMENT ON COLUMN CMD_REQUEST.DESTADDR IS '充电桩地址    ';

COMMENT ON COLUMN CMD_REQUEST.REMARK IS '备注    ';

COMMENT ON COLUMN CMD_REQUEST.CREATEDT IS '创建时间    ';

COMMENT ON COLUMN CMD_REQUEST.UPDATEDT IS '更新时间    ';
-- 外键索引

--删除表 计划任务表
ALTER TABLE CMD_SCHEDULEJOBS
  DROP PRIMARY KEY CASCADE;
	DROP TABLE CMD_SCHEDULEJOBS CASCADE CONSTRAINTS;

--
-- 创建表 计划任务表
--
CREATE TABLE CMD_SCHEDULEJOBS
(
	ID --- VARCHAR2(36) not null , --唯一Id(主键)	
	  POWERPILEID--- NUMBER(20,0)  null , --目标充电桩
	  INTERVAL--- VARCHAR2(32)  null , --执行频率
	  CMDTYPE--- VARCHAR2(1000)  null , --任务类型
	  TASKSTATE--- VARCHAR2(32)  null , --任务状态
	  JOB_MONTH--- NUMBER(10,0)  null , --月
	  JOB_WEEK--- NUMBER(10,0)  null , --周
	  JOB_DAY--- NUMBER(10,0)  null , --日
	  JOB_HOUR--- NUMBER(10,0)  null , --小时
	  JOB_MINUTE--- NUMBER(10,0)  null , --分钟
	  JOB_SECOND--- NUMBER(10,0)  null , --秒
	  RUNATDATE--- DATE  null , --指定运行日期
	  REMARK--- VARCHAR2(256)  null , --备注
	  REFID--- VARCHAR2(64)  null , --引用Id
	  REFENITY--- VARCHAR2(64)  null , --引用实体
	  CREATEDT--- DATE  null , --创建时间
	  UPDATEDT--- DATE  null , --更新时间 
	 constraint PK_CMD_SCHEDULEJOBS primary key (ID  )
);
--添加表计划任务表的注释
COMMENT ON TABLE CMD_SCHEDULEJOBS IS '计划任务表';
--添加表计划任务表的列注释

COMMENT ON COLUMN CMD_SCHEDULEJOBS.ID IS '唯一Id    ';

COMMENT ON COLUMN CMD_SCHEDULEJOBS.POWERPILEID IS '目标充电桩    ,3位充电站+2位分支箱+序号(3) ';

COMMENT ON COLUMN CMD_SCHEDULEJOBS.INTERVAL IS '执行频率    ,RunAT：执行一次
Repeat：重复执行，在Job_Day job_Hour不为0或空的时间点上执行 ';

COMMENT ON COLUMN CMD_SCHEDULEJOBS.CMDTYPE IS '任务类型    ,对时:
RefId: RefEntity无意义，任务执行时取当前系统时间
调价:
RefId：为“充电价格维护”表主键
RefEntity:为Cfg_ChargPrice ';

COMMENT ON COLUMN CMD_SCHEDULEJOBS.TASKSTATE IS '任务状态    ';

COMMENT ON COLUMN CMD_SCHEDULEJOBS.JOB_MONTH IS '月    ';

COMMENT ON COLUMN CMD_SCHEDULEJOBS.JOB_WEEK IS '周    ';

COMMENT ON COLUMN CMD_SCHEDULEJOBS.JOB_DAY IS '日    ';

COMMENT ON COLUMN CMD_SCHEDULEJOBS.JOB_HOUR IS '小时    ';

COMMENT ON COLUMN CMD_SCHEDULEJOBS.JOB_MINUTE IS '分钟    ';

COMMENT ON COLUMN CMD_SCHEDULEJOBS.JOB_SECOND IS '秒    ';

COMMENT ON COLUMN CMD_SCHEDULEJOBS.RUNATDATE IS '指定运行日期    ';

COMMENT ON COLUMN CMD_SCHEDULEJOBS.REMARK IS '备注    ';

COMMENT ON COLUMN CMD_SCHEDULEJOBS.REFID IS '引用Id    ';

COMMENT ON COLUMN CMD_SCHEDULEJOBS.REFENITY IS '引用实体    ';

COMMENT ON COLUMN CMD_SCHEDULEJOBS.CREATEDT IS '创建时间    ';

COMMENT ON COLUMN CMD_SCHEDULEJOBS.UPDATEDT IS '更新时间    ';
-- 外键索引

--删除表 命令执行响应
ALTER TABLE CMD_RESPONSE
  DROP PRIMARY KEY CASCADE;
	DROP TABLE CMD_RESPONSE CASCADE CONSTRAINTS;

--
-- 创建表 命令执行响应
--
CREATE TABLE CMD_RESPONSE
(
	ID --- VARCHAR2(36) not null , --唯一Id(主键)	
	  CMDID--- VARCHAR2(36)  null , --命令ID
	  RESPDATA--- VARCHAR2(1000)  null , --响应数据
	  RESPDT--- DATE  null , --响应时间
	  RESPRESULT--- NUMBER(1,0)  null , --响应结果
	  REMARK--- VARCHAR2(256)  null , --备注
	  CREATEDT--- DATE  null , --创建时间
	  UPDATEDT--- DATE  null , --更新时间 
	 constraint PK_CMD_RESPONSE primary key (ID  )
);
--添加表命令执行响应的注释
COMMENT ON TABLE CMD_RESPONSE IS '命令执行响应';
--添加表命令执行响应的列注释

COMMENT ON COLUMN CMD_RESPONSE.ID IS '唯一Id    ';

COMMENT ON COLUMN CMD_RESPONSE.CMDID IS '命令ID    ,唯一Id ';

COMMENT ON COLUMN CMD_RESPONSE.RESPDATA IS '响应数据    ';

COMMENT ON COLUMN CMD_RESPONSE.RESPDT IS '响应时间    ';

COMMENT ON COLUMN CMD_RESPONSE.RESPRESULT IS '响应结果    ';

COMMENT ON COLUMN CMD_RESPONSE.REMARK IS '备注    ';

COMMENT ON COLUMN CMD_RESPONSE.CREATEDT IS '创建时间    ';

COMMENT ON COLUMN CMD_RESPONSE.UPDATEDT IS '更新时间    ';
-- 外键索引

--删除表 计划任务执行日志
ALTER TABLE CMD_SCHEDULELOG
  DROP PRIMARY KEY CASCADE;
	DROP TABLE CMD_SCHEDULELOG CASCADE CONSTRAINTS;

--
-- 创建表 计划任务执行日志
--
CREATE TABLE CMD_SCHEDULELOG
(
	ID --- VARCHAR2(36) not null , --唯一Id(主键)	
	  TASKID--- VARCHAR2(36)  null , --计划任务Id
	  BEGINDT--- DATE  null , --开始执行时间
	  RESULT--- VARCHAR2(32)  null , --执行结果
	  REMARK--- VARCHAR2(256)  null , --备注
	  ENDDT--- DATE  null , --执行结束时间
	  CREATEDT--- DATE  null , --创建时间
	  UPDATEDT--- DATE  null , --更新时间 
	 constraint PK_CMD_SCHEDULELOG primary key (ID  )
);
--添加表计划任务执行日志的注释
COMMENT ON TABLE CMD_SCHEDULELOG IS '计划任务执行日志';
--添加表计划任务执行日志的列注释

COMMENT ON COLUMN CMD_SCHEDULELOG.ID IS '唯一Id    ';

COMMENT ON COLUMN CMD_SCHEDULELOG.TASKID IS '计划任务Id    ,唯一Id ';

COMMENT ON COLUMN CMD_SCHEDULELOG.BEGINDT IS '开始执行时间    ';

COMMENT ON COLUMN CMD_SCHEDULELOG.RESULT IS '执行结果    ';

COMMENT ON COLUMN CMD_SCHEDULELOG.REMARK IS '备注    ';

COMMENT ON COLUMN CMD_SCHEDULELOG.ENDDT IS '执行结束时间    ';

COMMENT ON COLUMN CMD_SCHEDULELOG.CREATEDT IS '创建时间    ';

COMMENT ON COLUMN CMD_SCHEDULELOG.UPDATEDT IS '更新时间    ';
-- 外键索引
