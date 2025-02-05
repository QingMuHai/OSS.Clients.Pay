﻿using OSS.Common.BasicMos.Resp;

namespace OSS.Clients.Pay.Wechat
{
    /// <summary>
    ///  响应基类
    /// </summary>
    public class WechatBaseResp : Resp
    {
        private string _code;

        /// <summary>
        ///  返回错误码
        /// </summary>
        public string code
        {
            get { return _code; }
            set
            {
                _code = value;
                if (!string.IsNullOrEmpty(_code))
                {
                    ret = (int) RespTypes.OperateFailed;
                }
            }
        }


        private string _message;

        /// <summary>
        ///  返回错误码
        /// </summary>
        public string message
        {
            get { return _message; }
            set
            {
                _message = value;
                if (!string.IsNullOrEmpty(_message))
                {
                    msg = _message;
                }
            }
        }

        /// <summary>
        ///  请求id
        /// </summary>
        public string request_id { get; set; }

        /// <summary>
        /// 响应内容
        /// </summary>
        public string response_body { get; set; }
    }

    internal static class RespMap
    {
        public static TResp ToResp<TResp>(this WechatBaseResp res)
            where TResp : WechatBaseResp, new()
        {
            var newRes = new TResp() { code = res.code, message = res.message,
                request_id =  res.request_id,
                response_body = res.response_body };
            newRes.ret = res.ret; // 因为code赋值时会覆写，放在后边
            return newRes;
        }
    }
}