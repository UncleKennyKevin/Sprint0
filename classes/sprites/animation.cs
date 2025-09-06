/*
using System;
using System.Collections.Generic;

namespace MonoGameLibrary.Graphics;
/*
public class animation
{

//FROM MONO GAME TUTORIAL

/// <summary>
/// The texture regions that make up the frames of this animation.  The order of the regions within the collection
/// are the order that the frames should be displayed in.
/// </summary>
public List<TextureRegion> Frames { get; set; }

/// <summary>
/// The amount of time to delay between each frame before moving to the next frame for this animation.
/// </summary>
public TimeSpan Delay { get; set; }

/// <summary>
/// Creates a new animation.
/// </summary>
public Animation()
{
    Frames = new List<TextureRegion>();
    Delay = TimeSpan.FromMilliseconds(100);
}

/// <summary>
/// Creates a new animation with the specified frames and delay.
/// </summary>
/// <param name="frames">An ordered collection of the frames for this animation.</param>
/// <param name="delay">The amount of time to delay between each frame of this animation.</param>
public Animation(List<TextureRegion> frames, TimeSpan delay)
{
    Frames = frames;
    Delay = delay;
}

<?xml version="1.0" encoding="utf-8"?>
<TextureAtlas>
    <Texture>images/atlas</Texture>
    <Regions>
        <Region name="slime-1" x="0" y="0" width="20" height="20" />
        <Region name="slime-2" x="0" y="20" width="20" height="20" />
        <Region name="bat-1" x="20" y="0" width="20" height="20" />
        <Region name="bat-2" x="20" y="20" width="20" height="20" />
        <Region name="bat-3" x="40" y="0" width="20" height="20" />
    </Regions>
    <Animations>
        <Animation name="slime-animation" delay="200">
            <Frame region="slime-1" />
            <Frame region="slime-2" />
        </Animation>
        <Animation name="bat-animation" delay="200">
            <Frame region="bat-1" />
            <Frame region="bat-2" />
            <Frame region="bat-1" />
            <Frame region="bat-3" />
        </Animation>
    </Animations>
</TextureAtlas>

}
*/