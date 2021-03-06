﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Wechat4net.Utils;

namespace Wechat4net.QY.Define.PushMessage
{
    /// <summary>
    /// 视频消息类型
    /// </summary>
    public class Video : Base
    {
        /// <summary>
        /// 消息类型
        /// </summary>
        internal override string MsgType { get { return "video"; } }
        /// <summary>
        /// 视频媒体文件id，可以调用上传媒体文件接口获取
        /// </summary>
        public string MediaID { set; get; }

        /// <summary>
        /// 视频消息的标题
        /// </summary>
        public string Title { set; get; }

        /// <summary>
        /// 视频消息的描述
        /// </summary>
        public string Description { set; get; }

        /// <summary>
        /// 是否是保密消息
        /// </summary>
        public bool IsSafe { set; get; }

        /// <summary>
        /// 实例化一个视频类型推送信息对象
        /// </summary>
        /// <param name="appId">应用ID</param>
        /// <param name="toUser">员工ID列表 最多支持1000个（当toUser、toParty、toTag都为空时，给全部员工发送）</param>
        /// <param name="toParty">部门ID列表 最多支持100个（当toUser、toParty、toTag都为空时，给全部员工发送）</param>
        /// <param name="toTag">标签ID列表 （当toUser、toParty、toTag都为空时，给全部员工发送）</param>
        /// <param name="mediaId">视频媒体文件id，可以调用上传媒体文件接口获取</param>
        /// <param name="title">视频消息的标题</param>
        /// <param name="description">视频消息的描述</param>
        /// <param name="isSafe">是否加密</param>
        public Video(string appId, List<string> toUser, List<string> toParty, List<string> toTag, string mediaId, string title, string description, bool isSafe)
        {
            this.messageType = Enums.QY.PushMessageEnum.Video;
            //this.MsgType = "video";
            this.AppID = appId;
            this.ToUser = toUser ?? new List<string>();
            this.ToParty = toParty ?? new List<string>();
            this.ToTag = toTag ?? new List<string>();
            this.MediaID = mediaId;
            this.Title = title;
            this.Description = description;
            this.IsSafe = isSafe;
        }

        internal override object GetData()
        {
            string touser, toparty, totag;
            this.GetPushObject(out touser, out toparty, out totag);

            var data = new
            {
                touser = touser,
                toparty = toparty,
                totag = totag,
                msgtype = MsgType,
                agentid = AppID,
                video = new
                {
                    media_id = MediaID,
                    title = Title,
                    description = Description
                },
                safe = IsSafe ? "1" : "0"
            };

            return data;
        }

    }
}
