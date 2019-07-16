using System;
using System.Collections.Generic;

namespace ConnectApp.Models.Api {
    [Serializable]
    public class LoginParameter {
        public string email;
        public string password;
    }

    [Serializable]
    public class WechatLoginParameter {
        public string code;
    }

    [Serializable]
    public class LikeArticleParameter {
        public string type;
        public string itemId;
    }

    [Serializable]
    public class ReactionParameter {
        public string reactionType;
    }

    [Serializable]
    public class SendCommentParameter {
        public string content;
        public string parentMessageId;
        public string nonce;
    }

    [Serializable]
    public class ReportParameter {
        public string itemType;
        public string itemId;
        public List<string> reasons;
    }

    [Serializable]
    public class FollowParameter {
        public string type;
        public string followeeId;
    }

    [Serializable]
    public class EditPersonalParameter {
        public string fullName;
        public string title;
        public string jobRoleId;
        public string placeId;
    }

    [Serializable]
    public class OpenAppParameter {
        public string userId;
        public string device;
        public string eventType;
        public DateTime appTime;
        public string data;
    }
}