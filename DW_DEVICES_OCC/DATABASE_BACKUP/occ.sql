/*
 Navicat Premium Data Transfer

 Source Server         : DW
 Source Server Type    : MySQL
 Source Server Version : 80017
 Source Host           : localhost:3306
 Source Schema         : occ

 Target Server Type    : MySQL
 Target Server Version : 80017
 File Encoding         : 65001

 Date: 21/03/2022 17:27:03
*/

SET NAMES utf8mb4;
SET FOREIGN_KEY_CHECKS = 0;

-- ----------------------------
-- Table structure for occ_app
-- ----------------------------
DROP TABLE IF EXISTS `occ_app`;
CREATE TABLE `occ_app`  (
  `id` int(150) NOT NULL AUTO_INCREMENT COMMENT 'id',
  `app_name` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL COMMENT '应用名',
  `remark` varchar(500) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL COMMENT '描述',
  `default_path` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL COMMENT '默认安装路径',
  `create_by` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL COMMENT '创建者',
  `create_time` datetime(0) NOT NULL COMMENT '创建时间',
  `update_time` datetime(0) NOT NULL COMMENT '最后更新时间',
  `update_by` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL COMMENT '更新者',
  `del_flag` char(1) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL COMMENT '删除标记(0未删除1已删除)',
  PRIMARY KEY (`id`) USING BTREE
) ENGINE = InnoDB AUTO_INCREMENT = 29 CHARACTER SET = utf8mb4 COLLATE = utf8mb4_0900_ai_ci COMMENT = 'OCC系统表APP表' ROW_FORMAT = Dynamic;

-- ----------------------------
-- Records of occ_app
-- ----------------------------
INSERT INTO `occ_app` VALUES (28, '123', '123', '123', '多维', '2022-03-18 14:45:51', '2022-03-18 14:45:51', '多维', '1');
INSERT INTO `occ_app` VALUES (29, '123', '123', '213', '多维', '2022-03-21 16:35:37', '2022-03-21 16:35:37', '多维', '1');

-- ----------------------------
-- Table structure for occ_app_device_bind
-- ----------------------------
DROP TABLE IF EXISTS `occ_app_device_bind`;
CREATE TABLE `occ_app_device_bind`  (
  `id` int(150) NOT NULL AUTO_INCREMENT COMMENT 'ID',
  `app_id` int(150) NOT NULL COMMENT 'AppID',
  `device_id` int(150) NOT NULL COMMENT '设备ID',
  `path` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL COMMENT '安装路径',
  `create_by` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL COMMENT '创建者',
  `create_time` datetime(0) NOT NULL COMMENT '创建时间',
  `update_time` datetime(0) NOT NULL COMMENT '最后更新时间',
  `update_by` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL COMMENT '更新者',
  `del_flag` char(1) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL COMMENT '删除标记(0未删除1已删除)',
  PRIMARY KEY (`id`) USING BTREE,
  INDEX `app_id`(`app_id`) USING BTREE,
  INDEX `device`(`device_id`) USING BTREE,
  CONSTRAINT `app` FOREIGN KEY (`app_id`) REFERENCES `occ_app` (`id`) ON DELETE RESTRICT ON UPDATE RESTRICT,
  CONSTRAINT `device` FOREIGN KEY (`device_id`) REFERENCES `occ_device` (`id`) ON DELETE RESTRICT ON UPDATE RESTRICT
) ENGINE = InnoDB AUTO_INCREMENT = 60 CHARACTER SET = utf8mb4 COLLATE = utf8mb4_0900_ai_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Records of occ_app_device_bind
-- ----------------------------
INSERT INTO `occ_app_device_bind` VALUES (56, 28, 12, '123', '多维', '2022-03-18 14:45:51', '2022-03-18 14:45:51', '多维', '1');
INSERT INTO `occ_app_device_bind` VALUES (57, 28, 14, '123', '多维', '2022-03-18 14:45:51', '2022-03-18 14:45:51', '多维', '1');
INSERT INTO `occ_app_device_bind` VALUES (58, 28, 19, '123', '多维', '2022-03-18 14:45:51', '2022-03-18 14:45:51', '多维', '1');
INSERT INTO `occ_app_device_bind` VALUES (59, 28, 6, '1231', '多维', '2022-03-18 14:45:57', '2022-03-18 14:45:57', '多维', '1');
INSERT INTO `occ_app_device_bind` VALUES (60, 29, 3, '213', '多维', '2022-03-21 16:35:37', '2022-03-21 16:35:37', '多维', '1');
INSERT INTO `occ_app_device_bind` VALUES (61, 29, 5, '213', '多维', '2022-03-21 16:35:37', '2022-03-21 16:35:37', '多维', '1');
INSERT INTO `occ_app_device_bind` VALUES (62, 29, 6, '213', '多维', '2022-03-21 16:35:37', '2022-03-21 16:35:37', '多维', '1');

-- ----------------------------
-- Table structure for occ_company
-- ----------------------------
DROP TABLE IF EXISTS `occ_company`;
CREATE TABLE `occ_company`  (
  `id` int(150) NOT NULL AUTO_INCREMENT COMMENT 'id',
  `name` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL COMMENT '公司名称',
  `remark` varchar(500) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL COMMENT '描述',
  `create_by` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL COMMENT '创建者',
  `create_time` datetime(0) NOT NULL COMMENT '创建时间',
  `update_time` datetime(0) NOT NULL COMMENT '最后更新时间',
  `update_by` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL COMMENT '更新者',
  `del_flag` char(1) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL COMMENT '删除标记(0未删除1已删除)',
  INDEX `id`(`id`) USING BTREE
) ENGINE = InnoDB AUTO_INCREMENT = 2 CHARACTER SET = utf8mb4 COLLATE = utf8mb4_0900_ai_ci COMMENT = 'OCC公司表' ROW_FORMAT = Dynamic;

-- ----------------------------
-- Records of occ_company
-- ----------------------------
INSERT INTO `occ_company` VALUES (1, '辽宁多维科技有限公司', '辽宁多维科技有限公司', 'wzq', '2022-03-04 09:15:14', '2022-03-04 09:15:14', 'wzq', '0');

-- ----------------------------
-- Table structure for occ_device
-- ----------------------------
DROP TABLE IF EXISTS `occ_device`;
CREATE TABLE `occ_device`  (
  `id` int(150) NOT NULL AUTO_INCREMENT COMMENT '设备ID',
  `name` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL COMMENT '自定义设备名称',
  `remark` varchar(500) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL COMMENT '备注',
  `mac` varchar(48) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL COMMENT '局域网Mac地址',
  `connect_type` int(2) NULL DEFAULT NULL COMMENT '连接方式，0 网口 1串口',
  `ip` varchar(32) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL COMMENT '局域网固定IP地址',
  `port` varchar(45) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL COMMENT '端口号',
  `serial` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL COMMENT '串口号',
  `type` int(2) NULL DEFAULT NULL COMMENT '设备类型',
  `create_by` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL COMMENT '创建者',
  `create_time` datetime(0) NOT NULL COMMENT '创建时间',
  `update_time` datetime(0) NOT NULL COMMENT '最后更新时间',
  `update_by` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL COMMENT '更新者',
  `del_flag` char(1) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL COMMENT '删除标记(0未删除1已删除)',
  `buad` int(45) NULL DEFAULT NULL COMMENT '串口连接波特率',
  PRIMARY KEY (`id`) USING BTREE,
  INDEX `设备类型`(`type`) USING BTREE,
  CONSTRAINT `设备类型` FOREIGN KEY (`type`) REFERENCES `occ_device_type` (`id`) ON DELETE RESTRICT ON UPDATE CASCADE
) ENGINE = InnoDB AUTO_INCREMENT = 20 CHARACTER SET = utf8mb4 COLLATE = utf8mb4_0900_ai_ci COMMENT = 'OCC外部链接设备表' ROW_FORMAT = Dynamic;

-- ----------------------------
-- Records of occ_device
-- ----------------------------
INSERT INTO `occ_device` VALUES (1, '李振', '李振的Windows', 'D4-5D-64-AA-1A-54', NULL, '192.168.0.98', NULL, NULL, 1, 'wzq', '2022-03-09 10:28:29', '2022-03-15 16:24:16', '多维', '0', NULL);
INSERT INTO `occ_device` VALUES (2, '王海塑', '王海塑PC', '1C-1B-0D-1B-23-DE', NULL, '192.168.0.60', NULL, NULL, 1, '多维', '2022-03-15 16:21:39', '2022-03-15 16:21:39', '多维', '1', NULL);
INSERT INTO `occ_device` VALUES (3, '白玉辉', '白玉辉的Windows10', 'D4-5D-64-B8-67-28', NULL, '192.168.0.140', NULL, NULL, 1, 'wzq', '2022-03-09 10:09:28', '2022-03-15 16:13:58', '多维', '0', NULL);
INSERT INTO `occ_device` VALUES (4, '测试投影', '测试投影COM7', '12-4B-0B-8A-0F-20', 0, '192.168.0.96', NULL, 'COM4', 2, '多维', '2022-03-17 14:38:11', '2022-03-17 15:01:48', '多维', '0', 0);
INSERT INTO `occ_device` VALUES (5, '王悦', '王悦PC', 'F4-B5-20-04-12-7F', NULL, '192.168.0.112', NULL, NULL, 1, '多维', '2022-03-16 09:25:36', '2022-03-16 09:25:36', '多维', '0', NULL);
INSERT INTO `occ_device` VALUES (6, '王志强', '王志强PC', '04-D4-C4-8E-7E-11', 0, '192.168.0.198', NULL, '', 1, '多维', '2022-03-16 14:50:58', '2022-03-17 14:39:37', '多维', '0', 0);
INSERT INTO `occ_device` VALUES (7, '投影4', '投影4', '12-4B-0B-8A-0F-20', 0, '192.168.0.96', NULL, '', 2, '多维', '2022-03-17 10:10:46', '2022-03-17 10:11:01', '多维', '0', NULL);
INSERT INTO `occ_device` VALUES (8, '李邵奇', '李邵奇PC', '40-8D-5C-BB-BD-21', NULL, '192.168.0.132', NULL, NULL, 1, '多维', '2022-03-15 16:21:07', '2022-03-15 16:21:07', '多维', '1', NULL);
INSERT INTO `occ_device` VALUES (9, '徐逸凡', '徐逸凡PC', 'D4-5D-64-AA-19-90', NULL, '192.168.0.29', NULL, NULL, 1, '多维', '2022-03-15 16:13:16', '2022-03-15 16:13:16', '多维', '1', NULL);
INSERT INTO `occ_device` VALUES (10, '葛家新', '葛家新PC', '1C-1B-0D-1B-22-3C', NULL, '192.168.0.168', NULL, NULL, 1, '多维', '2022-03-15 16:15:35', '2022-03-15 16:15:35', '多维', '1', NULL);
INSERT INTO `occ_device` VALUES (11, '王星宇', '', 'A8-5E-45-6C-81-5C', NULL, '192.168.0.157', NULL, NULL, 1, '多维', '2022-03-14 16:45:46', '2022-03-14 16:45:46', '多维', '1', NULL);
INSERT INTO `occ_device` VALUES (12, '关吉明', '关吉明\'s PC', 'D4-5D-64-02-8D-AD', NULL, '192.168.0.128', NULL, NULL, 1, '多维', '2022-03-14 16:20:15', '2022-03-15 16:14:01', '多维', '0', NULL);
INSERT INTO `occ_device` VALUES (13, '测试机01', '我座位边上的机器', '1C-1B-0D-60-56-D6', 0, '192.168.0.72', NULL, '', 1, 'wzq', '2022-03-09 09:06:54', '2022-03-18 14:19:06', '多维', '0', 0);
INSERT INTO `occ_device` VALUES (14, '李晓飞', '李晓飞PC', 'D4-5D-64-B8-68-89', NULL, '192.168.0.173', NULL, NULL, 1, '多维', '2022-03-15 16:06:28', '2022-03-15 16:06:28', '多维', '0', NULL);
INSERT INTO `occ_device` VALUES (15, '投影1', '投影1', '', 0, '192.168.0.55', NULL, 'COM5', 2, '多维', '2022-03-17 09:08:13', '2022-03-17 09:08:13', '多维', '0', NULL);
INSERT INTO `occ_device` VALUES (16, '王星宇\'s PC', NULL, 'A8-5E-45-6C-81-5C', NULL, '192.168.0.157', NULL, NULL, 1, '多维', '2022-03-14 16:16:45', '2022-03-14 16:16:45', '多维', '1', NULL);
INSERT INTO `occ_device` VALUES (17, '许远慧', '许远慧PC', 'D4-5D-64-B8-63-C3', NULL, '192.168.0.171', NULL, NULL, 1, '多维', '2022-03-15 16:09:20', '2022-03-15 16:09:20', '多维', '1', NULL);
INSERT INTO `occ_device` VALUES (18, '张秋', '张秋PC', 'D4-5D-64-B8-67-23', 0, '192.168.0.134', NULL, '', 1, '多维', '2022-03-18 14:17:27', '2022-03-18 14:17:27', '多维', '1', 0);
INSERT INTO `occ_device` VALUES (19, '测试机01', '我座位边上的机器', '1C-1B-0D-60-56-D6', 0, '192.168.0.72', NULL, '', 1, 'wzq', '2022-03-09 09:06:54', '2022-03-18 14:19:06', '多维', '0', 0);

-- ----------------------------
-- Table structure for occ_device_execute
-- ----------------------------
DROP TABLE IF EXISTS `occ_device_execute`;
CREATE TABLE `occ_device_execute`  (
  `id` int(11) NOT NULL AUTO_INCREMENT COMMENT '主键id',
  `name` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL COMMENT '操作名',
  `device_type` int(255) NULL DEFAULT NULL COMMENT '设备类型',
  `remark` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL COMMENT '操作描述',
  `create_by` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL COMMENT '创建者',
  `create_time` datetime(0) NOT NULL COMMENT '创建时间',
  `update_time` datetime(0) NOT NULL COMMENT '最后更新时间',
  `update_by` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL COMMENT '更新者',
  `del_flag` char(1) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL COMMENT '删除标记(0未删除1已删除)',
  PRIMARY KEY (`id`) USING BTREE,
  INDEX `device_execute_device_type_id`(`device_type`) USING BTREE,
  CONSTRAINT `device_execute_device_type_id` FOREIGN KEY (`device_type`) REFERENCES `occ_device_type` (`id`) ON DELETE RESTRICT ON UPDATE RESTRICT
) ENGINE = InnoDB CHARACTER SET = utf8mb4 COLLATE = utf8mb4_0900_ai_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Records of occ_device_execute
-- ----------------------------
INSERT INTO `occ_device_execute` VALUES (1, '开机', 1, 'PC端开机', 'dw', '2022-03-21 09:17:01', '2022-03-21 09:17:03', 'dw', '0');
INSERT INTO `occ_device_execute` VALUES (2, '关机', 1, 'PC端关机', 'dw', '2022-03-21 09:17:01', '2022-03-21 09:17:03', 'dw', '0');
INSERT INTO `occ_device_execute` VALUES (3, '重启', 1, 'PC重启', 'dw', '2022-03-21 09:17:01', '2022-03-21 09:17:03', 'dw', '0');
INSERT INTO `occ_device_execute` VALUES (4, '开机', 2, '开启投影设备', 'dw', '2022-03-21 15:00:49', '2022-03-21 15:00:51', 'dw', '0');
INSERT INTO `occ_device_execute` VALUES (5, '关机', 2, '关闭投影设备', 'dw', '2022-03-21 15:01:12', '2022-03-21 15:01:17', 'dw', '0');
INSERT INTO `occ_device_execute` VALUES (6, '3D自动', 2, '3D自动', 'dw', '2022-03-21 15:01:38', '2022-03-21 15:01:40', 'dw', '0');
INSERT INTO `occ_device_execute` VALUES (7, '3D连续帧', 2, '3D连续帧', 'dw', '2022-03-21 15:01:38', '2022-03-21 15:01:40', 'dw', '0');
INSERT INTO `occ_device_execute` VALUES (8, '3D翻转开', 2, '3D翻转开', 'dw', '2022-03-21 15:01:38', '2022-03-21 15:01:40', 'dw', '0');
INSERT INTO `occ_device_execute` VALUES (9, '3D翻转关', 2, '3D翻转关', 'dw', '2022-03-21 15:01:38', '2022-03-21 15:01:40', 'dw', '0');
INSERT INTO `occ_device_execute` VALUES (10, '光闸开', 2, '光闸开', 'dw', '2022-03-21 15:01:38', '2022-03-21 15:01:40', 'dw', '0');
INSERT INTO `occ_device_execute` VALUES (11, '光闸关', 2, '光闸关', 'dw', '2022-03-21 15:01:38', '2022-03-21 15:01:40', 'dw', '0');
INSERT INTO `occ_device_execute` VALUES (12, '帧延迟', 2, '帧延迟', 'dw', '2022-03-21 15:01:38', '2022-03-21 15:01:40', 'dw', '0');
INSERT INTO `occ_device_execute` VALUES (13, '3D Syncout 开', 2, '3D Syncout 开', 'dw', '2022-03-21 15:01:38', '2022-03-21 15:01:40', 'dw', '0');
INSERT INTO `occ_device_execute` VALUES (14, '3D Syncout 关', 2, '3D Syncout 关', 'dw', '2022-03-21 15:01:38', '2022-03-21 15:01:40', 'dw', '0');
INSERT INTO `occ_device_execute` VALUES (15, '电源状态', 2, '电源状态', 'dw', '2022-03-21 15:01:38', '2022-03-21 15:01:40', 'dw', '0');
INSERT INTO `occ_device_execute` VALUES (16, '开启', 3, '开启音响设备', 'dw', '2022-03-21 15:01:38', '2022-03-21 15:01:40', 'dw', '0');
INSERT INTO `occ_device_execute` VALUES (17, '关闭', 3, '关闭音响设备', 'dw', '2022-03-21 15:01:38', '2022-03-21 15:01:40', 'dw', '0');
INSERT INTO `occ_device_execute` VALUES (18, '全开', 4, '灯光全开', 'dw', '2022-03-21 15:01:38', '2022-03-21 15:01:40', 'dw', '0');
INSERT INTO `occ_device_execute` VALUES (19, '全关', 4, '灯光全关', 'dw', '2022-03-21 15:01:38', '2022-03-21 15:01:40', 'dw', '0');
INSERT INTO `occ_device_execute` VALUES (20, '加载7Th工程文件', 5, '加载7Th工程文件', 'dw', '2022-03-21 15:01:38', '2022-03-21 15:01:40', 'dw', '0');
INSERT INTO `occ_device_execute` VALUES (21, '翻转左右眼立体', 5, '翻转左右眼立体', 'dw', '2022-03-21 15:06:37', '2022-03-21 15:06:39', 'dw', '0');
INSERT INTO `occ_device_execute` VALUES (22, '双眼网格', 5, '双眼网格', 'dw', '2022-03-21 15:07:00', '2022-03-21 15:07:03', 'dw', '0');
INSERT INTO `occ_device_execute` VALUES (23, '投影编号', 5, '投影编号', 'dw', '2022-03-21 15:07:00', '2022-03-21 15:07:03', 'dw', '0');

-- ----------------------------
-- Table structure for occ_device_type
-- ----------------------------
DROP TABLE IF EXISTS `occ_device_type`;
CREATE TABLE `occ_device_type`  (
  `id` int(2) NOT NULL AUTO_INCREMENT COMMENT 'id',
  `name` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL COMMENT '类型名',
  `remark` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL COMMENT '描述',
  `create_by` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL COMMENT '创建者',
  `create_time` datetime(0) NOT NULL COMMENT '创建时间',
  `update_time` datetime(0) NOT NULL COMMENT '最后更新时间',
  `update_by` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL COMMENT '更新者',
  `del_flag` char(1) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL COMMENT '删除标记(0未删除1已删除)',
  PRIMARY KEY (`id`) USING BTREE,
  INDEX `remark`(`remark`) USING BTREE,
  INDEX `name`(`name`) USING BTREE
) ENGINE = InnoDB AUTO_INCREMENT = 5 CHARACTER SET = utf8mb4 COLLATE = utf8mb4_0900_ai_ci COMMENT = 'OCC设备类型' ROW_FORMAT = Dynamic;

-- ----------------------------
-- Records of occ_device_type
-- ----------------------------
INSERT INTO `occ_device_type` VALUES (1, '客户机', 'Windows10 电脑', 'wzq', '2022-03-03 15:22:23', '2022-03-03 15:22:25', 'wzq', '0');
INSERT INTO `occ_device_type` VALUES (2, '投影', '投影机', 'wzq', '2022-03-03 15:22:51', '2022-03-03 15:22:54', 'wzq', '0');
INSERT INTO `occ_device_type` VALUES (3, '音响', '音响设备', 'wzq', '2022-03-03 15:23:18', '2022-03-03 15:23:20', 'wzq', '0');
INSERT INTO `occ_device_type` VALUES (4, '灯光', '灯光设备', 'wzq', '2022-03-03 15:23:37', '2022-03-03 15:23:39', 'wzq', '0');
INSERT INTO `occ_device_type` VALUES (5, '7th主机', '7th主机', 'wzq', '2022-03-21 14:59:10', '2022-03-21 14:59:12', 'wzq', '0');
INSERT INTO `occ_device_type` VALUES (6, 'ZZ-I0808', 'ZZ-I0808', 'wzq', '2022-03-21 14:59:35', '2022-03-21 14:59:37', 'wzq', '0');
INSERT INTO `occ_device_type` VALUES (7, 'TCP-KP-I404', 'TCP-KP-I404', 'wzq', '2022-03-21 14:59:55', '2022-03-21 14:59:57', 'wzq', '0');

-- ----------------------------
-- Table structure for occ_group
-- ----------------------------
DROP TABLE IF EXISTS `occ_group`;
CREATE TABLE `occ_group`  (
  `id` int(11) NOT NULL AUTO_INCREMENT COMMENT '主键ID',
  `name` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL COMMENT '分组名',
  `company_id` int(11) NULL DEFAULT NULL COMMENT '所属公司ID',
  `remark` varchar(500) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL COMMENT '描述',
  `create_by` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL COMMENT '创建者',
  `create_time` datetime(0) NOT NULL COMMENT '创建时间',
  `update_time` datetime(0) NOT NULL COMMENT '最后更新时间',
  `update_by` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL COMMENT '更新者',
  `del_flag` char(1) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL COMMENT '删除标记(0未删除1已删除)',
  PRIMARY KEY (`id`) USING BTREE
) ENGINE = InnoDB AUTO_INCREMENT = 1 CHARACTER SET = utf8mb4 COLLATE = utf8mb4_0900_ai_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Records of occ_group
-- ----------------------------
INSERT INTO `occ_group` VALUES (1, '分组1', 1, '关机测试', 'dw', '2022-03-21 10:22:28', '2022-03-21 10:22:30', 'dw', '0');
INSERT INTO `occ_group` VALUES (2, '分组2', 1, '开机测试', 'dw', '2022-03-21 10:22:28', '2022-03-21 10:22:30', 'dw', '0');
INSERT INTO `occ_group` VALUES (5, '分组3', 1, '分组3', '多维', '2022-03-21 13:05:17', '2022-03-21 13:05:17', '多维', '1');
INSERT INTO `occ_group` VALUES (6, '分组2-11', 1, '开机测试', 'dw', '2022-03-21 10:22:28', '2022-03-21 13:19:50', '多维', '1');

-- ----------------------------
-- Table structure for occ_group_device_execute
-- ----------------------------
DROP TABLE IF EXISTS `occ_group_device_execute`;
CREATE TABLE `occ_group_device_execute`  (
  `id` int(11) NOT NULL AUTO_INCREMENT COMMENT '主键iD',
  `group_id` int(11) NULL DEFAULT NULL COMMENT '分组Id',
  `device_id` int(255) NULL DEFAULT NULL COMMENT '设备ID',
  `delay` int(11) NULL DEFAULT NULL COMMENT '演示事件(s)',
  `execute_id` int(11) NULL DEFAULT NULL COMMENT '处理模式id',
  `sort_id` int(11) NULL DEFAULT NULL COMMENT '排序',
  `create_by` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL COMMENT '创建者',
  `create_time` datetime(0) NOT NULL COMMENT '创建时间',
  `update_time` datetime(0) NOT NULL COMMENT '最后更新时间',
  `update_by` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL COMMENT '更新者',
  `del_flag` char(1) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL COMMENT '删除标记(0未删除1已删除)',
  PRIMARY KEY (`id`) USING BTREE
) ENGINE = InnoDB CHARACTER SET = utf8mb4 COLLATE = utf8mb4_0900_ai_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Records of occ_group_device_execute
-- ----------------------------
INSERT INTO `occ_group_device_execute` VALUES (1, 1, 13, 1, 1, 2, 'dw', '2022-03-21 10:32:12', '2022-03-21 10:32:13', 'dw', '0');
INSERT INTO `occ_group_device_execute` VALUES (2, 2, 13, 1, 2, 1, 'dw', '2022-03-21 10:32:12', '2022-03-21 10:32:13', 'dw', '0');
INSERT INTO `occ_group_device_execute` VALUES (3, 1, 13, 1, 2, 1, 'dw', '2022-03-21 10:32:12', '2022-03-21 10:32:13', 'dw', '0');
INSERT INTO `occ_group_device_execute` VALUES (4, 1, 13, 1, 2, 1, '多维', '2022-03-21 16:01:21', '2022-03-21 16:01:21', '多维', '1');
INSERT INTO `occ_group_device_execute` VALUES (5, 1, 6, 1, 2, 2, '多维', '2022-03-21 16:47:13', '2022-03-21 16:47:13', '多维', '0');

-- ----------------------------
-- Table structure for occ_user
-- ----------------------------
DROP TABLE IF EXISTS `occ_user`;
CREATE TABLE `occ_user`  (
  `id` int(128) NOT NULL AUTO_INCREMENT COMMENT '用户ID',
  `user_name` varchar(30) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL COMMENT '用户昵称',
  `login_name` varchar(30) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL COMMENT '登陆账号',
  `password` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL COMMENT '登录密码',
  `identity_id` char(18) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL COMMENT '身份证号',
  `user_type` int(4) NOT NULL COMMENT '用户类型',
  `email` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL COMMENT '邮箱',
  `sex` char(1) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL COMMENT '性别（0未知1男2女）',
  `phonenumber` varchar(11) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL COMMENT '手机号',
  `remark` varchar(500) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL COMMENT '备注',
  `company_id` int(150) NOT NULL COMMENT '所属公司ID',
  `login_ip` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL COMMENT '登录IP\r\n',
  `login_date` datetime(0) NULL DEFAULT NULL COMMENT '最后登录时间',
  `create_by` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL COMMENT '创建者',
  `create_time` datetime(0) NOT NULL COMMENT '创建时间',
  `update_time` datetime(0) NOT NULL COMMENT '最后更新时间',
  `update_by` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL COMMENT '更新者',
  `del_flag` char(1) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL COMMENT '删除标记(0未删除1已删除)',
  `user_status` char(1) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL COMMENT '账号状态(备用)',
  PRIMARY KEY (`id`) USING BTREE,
  INDEX `用户类型`(`user_type`) USING BTREE,
  INDEX `公司绑定`(`company_id`) USING BTREE,
  CONSTRAINT `公司绑定` FOREIGN KEY (`company_id`) REFERENCES `occ_company` (`id`) ON DELETE CASCADE ON UPDATE CASCADE,
  CONSTRAINT `用户类型` FOREIGN KEY (`user_type`) REFERENCES `occ_user_type` (`id`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE = InnoDB AUTO_INCREMENT = 13 CHARACTER SET = utf8mb4 COLLATE = utf8mb4_0900_ai_ci COMMENT = 'OCC用户表' ROW_FORMAT = Dynamic;

-- ----------------------------
-- Records of occ_user
-- ----------------------------
INSERT INTO `occ_user` VALUES (1, '123', '123', '123', '', 3, '123', '1', '', '', 1, NULL, NULL, '多维', '2022-03-08 11:11:05', '2022-03-08 11:11:05', '多维', '1', NULL);
INSERT INTO `occ_user` VALUES (2, '123', '123', '123', '', 3, '123', '1', '', '', 1, NULL, NULL, '多维', '2022-03-08 11:10:56', '2022-03-08 11:10:56', '多维', '1', NULL);
INSERT INTO `occ_user` VALUES (3, '123444', '124124', '412412', '', 1, '4124124', '1', '11111111111', '测试测试测试测试测试测试测试测试测试测试测试测试测试测试测试测试测试测试测试测试测试测试测试测试测试测试测试测试\n测试\n测试\n测试\n测试\n测试\n测试\n测试\n测试\n测试\n测试\n测试\n测试\n测试\n', 1, NULL, NULL, '多维', '2022-03-08 13:24:10', '2022-03-08 13:24:10', '多维', '0', NULL);
INSERT INTO `occ_user` VALUES (4, '123', '123', '123', '', 3, '123', '1', '', '', 1, NULL, NULL, '多维', '2022-03-08 11:11:05', '2022-03-08 11:11:05', '多维', '1', NULL);
INSERT INTO `occ_user` VALUES (5, '123', '123', '123', '', 3, '123', '1', '', '', 1, NULL, NULL, '多维', '2022-03-08 11:11:05', '2022-03-08 11:11:05', '多维', '1', NULL);
INSERT INTO `occ_user` VALUES (6, '123', '123', '123', '', 3, '123', '1', '', '', 1, NULL, NULL, '多维', '2022-03-08 11:11:04', '2022-03-08 11:11:04', '多维', '1', NULL);
INSERT INTO `occ_user` VALUES (7, '123', '123', '123', '', 3, '123', '1', '', '', 1, NULL, NULL, '多维', '2022-03-08 11:11:04', '2022-03-08 11:11:04', '多维', '0', NULL);
INSERT INTO `occ_user` VALUES (8, '123', '369', '369', '', 1, '123', '1', '', '', 1, NULL, NULL, '多维', '2022-03-09 11:01:46', '2022-03-09 11:01:46', '多维', '0', NULL);
INSERT INTO `occ_user` VALUES (9, '234', '234', '234', '', 3, '', '2', '', '', 1, NULL, NULL, '多维', '2022-03-08 11:16:03', '2022-03-08 11:16:03', '多维', '0', NULL);
INSERT INTO `occ_user` VALUES (10, '多维', 'admin', 'duowei', '123456789012345678', 1, '123456789@duowei.com', '1', '12345678901', '多维OCC管理员账号.', 1, NULL, NULL, 'wzq', '2022-03-03 14:53:28', '2022-03-21 08:52:04', '多维', '0', NULL);
INSERT INTO `occ_user` VALUES (11, '555', '55', '55', '', 2, '', '0', '', '', 1, NULL, NULL, '多维', '2022-03-08 11:16:57', '2022-03-08 11:16:57', '多维', '1', NULL);
INSERT INTO `occ_user` VALUES (12, '123', '123', '123', '', 3, '123', '1', '', '', 1, NULL, NULL, '多维', '2022-03-08 11:11:05', '2022-03-08 11:11:05', '多维', '1', NULL);
INSERT INTO `occ_user` VALUES (13, 'test1', '123', '123', '123', 2, '123', '0', '123', '123', 1, NULL, NULL, '多维', '2022-03-21 08:52:31', '2022-03-21 08:52:31', '多维', '0', NULL);

-- ----------------------------
-- Table structure for occ_user_type
-- ----------------------------
DROP TABLE IF EXISTS `occ_user_type`;
CREATE TABLE `occ_user_type`  (
  `id` int(4) NOT NULL AUTO_INCREMENT COMMENT 'id',
  `name` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL COMMENT '类型名',
  `authority_level` int(255) NOT NULL COMMENT '位运算权限级别',
  `create_by` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL COMMENT '创建者',
  `create_time` datetime(0) NOT NULL COMMENT '创建时间',
  `update_time` datetime(0) NOT NULL COMMENT '最后更新时间',
  `update_by` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL COMMENT '更新者',
  `del_flag` char(1) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL COMMENT '删除标记(0未删除1已删除)',
  PRIMARY KEY (`id`) USING BTREE
) ENGINE = InnoDB AUTO_INCREMENT = 4 CHARACTER SET = utf8mb4 COLLATE = utf8mb4_0900_ai_ci COMMENT = 'OCC用户类型用户权限表' ROW_FORMAT = Dynamic;

-- ----------------------------
-- Records of occ_user_type
-- ----------------------------
INSERT INTO `occ_user_type` VALUES (1, '管理员', 63, 'wzq', '2022-03-03 14:54:03', '2022-03-03 14:54:04', 'wzq', '0');
INSERT INTO `occ_user_type` VALUES (2, '教员', 63, 'wzq', '2022-03-04 08:59:55', '2022-03-04 08:59:58', 'wzq', '0');
INSERT INTO `occ_user_type` VALUES (3, '学员', 1, 'wzq', '2022-03-04 09:00:15', '2022-03-04 09:00:18', 'wzq', '0');

SET FOREIGN_KEY_CHECKS = 1;
