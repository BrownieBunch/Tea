using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace GameEffects
{
    public static class AudioFadeScript
    {
        public static IEnumerator FadeOut(AudioSource audioSource, float FadeTime)
        {
            float startVolume = audioSource.volume;

            while (audioSource.volume > 0)
            {
                audioSource.volume -= startVolume * Time.deltaTime / FadeTime;

                yield return null;
            }

            audioSource.Stop();
            audioSource.volume = startVolume;
        }

        public static IEnumerator FadeIn(AudioSource audioSource, float FadeTime)
        {
            float startVolume = 0.2f;

            audioSource.volume = 0;
            audioSource.Play();

            while (audioSource.volume < 1.0f)
            {
                audioSource.volume += startVolume * Time.deltaTime / FadeTime;

                yield return null;
            }

            audioSource.volume = 1f;
        }
    }
    public static class LightFadeScript
    {

        public static IEnumerator fadeInLight(Light this_light, float max, float flashDuration)
        {
            float enterIntensity = this_light.intensity;


            while (this_light.intensity < max)

            {
                this_light.intensity += (max - enterIntensity) * Time.deltaTime / flashDuration;
                yield return null;
            }
            this_light.intensity = max;
        }

        public static IEnumerator fadeOutLight(Light this_light, float min, float flashDuration)
        {
            float enterIntensity = this_light.intensity;

            while (this_light.intensity > min)

            {
                this_light.intensity -= (enterIntensity - min) * Time.deltaTime / flashDuration;
                yield return null;
            }

            this_light.intensity = min;

        }

        public static IEnumerator bombLight(Light this_light, float max, float flashDuration)
        {
            float enterIntensity = this_light.intensity;
            float increment = this_light.intensity * 30 / 100;
            while (this_light.intensity < max)
            {
                this_light.intensity += increment;
                yield return null;
            }

        }

    }
    public static class Scale
    {
        public static Vector2 Scale2Bounds()
        {
            float heightInWorldUnits = Camera.main.orthographicSize * 2;
            float widthInWorldUnits = Camera.main.aspect * Camera.main.orthographicSize * 2;
            return new Vector2(widthInWorldUnits, heightInWorldUnits);
        }
    }
    public static class Align
    {
        public static Vector2 Centered2Screen()
        {
            return new Vector2(Camera.main.transform.position.x, Camera.main.transform.position.y);
        }
    }
    public static class Fade
    {
        public static class SpriteFadeScript
        {
            public static IEnumerator FadeInLinearly(GameObject go, float startingalpha, float maxalpha, float durationInSeconds)
            {
                //get it
                SpriteRenderer spriteRenderer = go.GetComponent<SpriteRenderer>();
                //counter it
                float currentalpha = startingalpha;
                //loop it
                while (currentalpha < maxalpha)
                {
                    spriteRenderer.color = new Color(spriteRenderer.color.r, spriteRenderer.color.g, spriteRenderer.color.b, currentalpha);
                    currentalpha += ((maxalpha - startingalpha) / durationInSeconds) * Time.deltaTime;
                    Debug.Log(spriteRenderer.color);
                    yield return null;
                }
                spriteRenderer.color = new Color(spriteRenderer.color.r, spriteRenderer.color.g, spriteRenderer.color.b, maxalpha);
            }

            public static IEnumerator FadeOutLinearly(GameObject go, float startingalpha, float minalpha, float durationInSeconds)
            {
                //get it
                SpriteRenderer spriteRenderer = go.GetComponent<SpriteRenderer>();
                //counter it
                float currentalpha = startingalpha;
                //loop it
                while (currentalpha > minalpha)
                {
                    spriteRenderer.color = new Color(spriteRenderer.color.r, spriteRenderer.color.g, spriteRenderer.color.b, currentalpha);
                    currentalpha -= ((startingalpha - minalpha) / durationInSeconds) * Time.deltaTime;
                    // Debug.Log(spriteRenderer.color);
                    yield return null;
                }
                spriteRenderer.color = new Color(spriteRenderer.color.r, spriteRenderer.color.g, spriteRenderer.color.b, minalpha);

            }

        }

        public static class AudioFadeScript
        {
            public static IEnumerator FadeOut(AudioSource audioSource, float FadeTime)
            {
                float startVolume = audioSource.volume;

                while (audioSource.volume > 0)
                {
                    audioSource.volume -= startVolume * Time.deltaTime / FadeTime;

                    yield return null;
                }

                audioSource.Stop();
                audioSource.volume = startVolume;
            }

            public static IEnumerator FadeIn(AudioSource audioSource, float FadeTime)
            {
                float startVolume = 0.2f;

                audioSource.volume = 0;
                audioSource.Play();

                while (audioSource.volume < 1.0f)
                {
                    audioSource.volume += startVolume * Time.deltaTime / FadeTime;

                    yield return null;
                }

                audioSource.volume = 1f;
            }
        }

        public static class LightFadeScript
        {

            public static IEnumerator fadeInLight(Light this_light, float max, float flashDuration)
            {
                float enterIntensity = this_light.intensity;


                while (this_light.intensity < max)

                {
                    this_light.intensity += (max - enterIntensity) * Time.deltaTime / flashDuration;
                    yield return null;
                }
                this_light.intensity = max;
            }

            public static IEnumerator fadeOutLight(Light this_light, float min, float flashDuration)
            {
                float enterIntensity = this_light.intensity;

                while (this_light.intensity > min)

                {
                    this_light.intensity -= (enterIntensity - min) * Time.deltaTime / flashDuration;
                    yield return null;
                }

                this_light.intensity = min;

            }

            public static IEnumerator bombLight(Light this_light, float max, float flashDuration)
            {
                float enterIntensity = this_light.intensity;
                float increment = this_light.intensity * 30 / 100;
                while (this_light.intensity < max)
                {
                    this_light.intensity += increment;
                    yield return null;
                }

            }

        }
        //new Waitfor?
    }
    public class Timer
    {
        float timestamp = Time.time;
        float period = 1 / Time.deltaTime;
        public bool tickflag;

        void Tick()
        {
            float nexttimestamp = timestamp + period;
            if (Time.time > nexttimestamp)
            { tickflag = true; }
        }


    }

}
