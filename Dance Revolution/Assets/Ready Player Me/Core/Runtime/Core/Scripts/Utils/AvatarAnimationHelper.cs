using System.Collections.Generic;
using ReadyPlayerMe.Core.Data;
using UnityEngine;

namespace ReadyPlayerMe.Core
{
    /// <summary>
    /// This static class contains useful helper functions for setting up Animators on Ready Player Me Avatars.
    /// </summary>
    public static class AvatarAnimationHelper
    {
        private const string TAG = nameof(AvatarProcessor);

        private const string MASCULINE_ANIMATION_AVATAR_NAME = "AnimationAvatars/Masculine";
        private const string FEMININE_ANIMATION_AVATAR_NAME = "AnimationAvatars/Feminine";
        private const string XR_MASCULINE_ANIMATION_AVATAR_NAME = "AnimationAvatars/Masculine_XR";
        private const string XR_FEMININE_ANIMATION_AVATAR_NAME = "AnimationAvatars/Feminine_XR";

        private static readonly Dictionary<string, Avatar> AnimationAvatarCache = new();

        public static void SetupAnimator(AvatarMetadata avatarMetadata, GameObject avatar)
        {
            Debug.Log("Setting up animator for avatar");
            var animator = avatar.GetComponent<Animator>();
            if (animator == null)
            {
                Debug.Log("Animator component not found, adding one.");
                animator = avatar.AddComponent<Animator>();
            }
            SetupAnimator(avatarMetadata, animator);
        }

        public static void SetupAnimator(AvatarMetadata avatarMetadata, Animator animator)
        {
            animator.avatar = GetAnimationAvatar(avatarMetadata);
        }

        public static Avatar GetAnimationAvatar(AvatarMetadata avatarMetadata)
        {
            Debug.Log("Getting animation avatar");
            var path = GetAvatarPath(avatarMetadata);
            if (path == null)
            {
                Debug.LogWarning($"[{TAG}] Animation avatar not found for body type {avatarMetadata.BodyType}");
                return null;
            }

            if (!AnimationAvatarCache.TryGetValue(path, out var avatar))
            {
                Debug.Log($"Loading animation avatar from path: {path}");
                var model = Resources.Load<GameObject>(path);
                if (model == null)
                {
                    Debug.LogWarning($"[{TAG}] Animation avatar not found at path: {path}");
                    return null;
                }

                if (model.TryGetComponent(out Animator animator))
                {
                    Debug.Log("Animator component found on animation avatar.");
                    avatar = animator.avatar;
                    AnimationAvatarCache[path] = avatar;
                }
            }
            Debug.Log("Returning animation avatar");
            return avatar;
        }

        private static string GetAvatarPath(AvatarMetadata avatarMetadata)
        {
            return avatarMetadata.BodyType switch
            {
                BodyType.FullBody => GetFullbodyAvatarPath(avatarMetadata.OutfitGender),
                BodyType.FullBodyXR => GetFullbodyXrAvatarPath(avatarMetadata.OutfitGender),
                _ => null
            };
        }

        private static string GetFullbodyAvatarPath(OutfitGender outfitGender)
        {
            return outfitGender == OutfitGender.Masculine
                ? MASCULINE_ANIMATION_AVATAR_NAME
                : FEMININE_ANIMATION_AVATAR_NAME;
        }

        private static string GetFullbodyXrAvatarPath(OutfitGender outfitGender)
        {
            return outfitGender == OutfitGender.Masculine
                ? XR_MASCULINE_ANIMATION_AVATAR_NAME
                : XR_FEMININE_ANIMATION_AVATAR_NAME;
        }
    }
}
